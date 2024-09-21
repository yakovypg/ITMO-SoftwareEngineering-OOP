using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class ComputerInspector
{
    private readonly Computer _computer;

    public ComputerInspector(Computer computer)
    {
        _computer = computer ?? throw new ArgumentNullException(nameof(computer));
    }

    public void Inspect()
    {
        if (!HasAllNecessaryComponents())
            throw new MissingComponentException();

        InspectAllComponents();
    }

    public void InspectAllComponents()
    {
        if (!VerifyCpuCompatibility())
            throw new IncompatibleComponentException(typeof(Cpu));

        if (!VerifyCoolingSystemCompatibility())
            throw new IncompatibleComponentException(typeof(CpuCoolingSystem));

        if (!VerifyRamsCompatibility())
            throw new IncompatibleComponentException(typeof(Ram));

        if (!VerifyGpuCompatibility())
            throw new IncompatibleComponentException(typeof(Gpu));

        if (!VerifySsdDrivesCompatibility())
            throw new IncompatibleComponentException(typeof(SsdDrive));

        if (!VerifyComputerCaseCompatibility())
            throw new IncompatibleComponentException(typeof(ComputerCase));

        if (!VerifyPowerSupplyCompatibility())
            throw new IncompatibleComponentException(typeof(PowerSupply));

        if (!VerifyWiFiAdapterCompatibility())
            throw new IncompatibleComponentException(typeof(WiFiAdapter));

        if (!VerifyMotherboardPciELines() || !VerifyMotherboardSataPorts())
            throw new IncompatibleComponentException(typeof(Motherboard));
    }

    public bool IsValid()
    {
        return HasAllNecessaryComponents()
            && VerifyCpuCompatibility()
            && VerifyCoolingSystemCompatibility()
            && VerifyRamsCompatibility()
            && VerifyGpuCompatibility()
            && VerifySsdDrivesCompatibility()
            && VerifyComputerCaseCompatibility()
            && VerifyPowerSupplyCompatibility()
            && VerifyWiFiAdapterCompatibility()
            && VerifyMotherboardPciELines()
            && VerifyMotherboardSataPorts();
    }

    public bool HasNotRecommendedComponentsCombinations()
    {
        return !VerifyCoolingSystemDissipatedHeatMass();
    }

    public bool VerifyPowerSupplyRecommendations()
    {
        return _computer.PowerSupply is null
            || _computer.PowerSupply.RecommendedMaxLoad >= CalcComponentsPowerConsumption();
    }

    private bool HasAllNecessaryComponents()
    {
        return _computer.Motherboard is not null
            && _computer.Cpu is not null
            && _computer.CoolingSystem is not null
            && _computer.Rams.Count > 0
            && (_computer.Cpu.HasEmbeddedVideoCore || _computer.Gpu is not null)
            && (_computer.HardDisks.Count > 0 || _computer.SsdDrives.Count > 0)
            && _computer.Case is not null
            && _computer.PowerSupply is not null;
    }

    private bool VerifyCpuCompatibility()
    {
        return _computer.Cpu is null
            || _computer.Motherboard is null
            || (_computer.Cpu.Socket == _computer.Motherboard.Socket
                && _computer.Motherboard.Bios.SupportedCpus.Contains(_computer.Cpu.Name));
    }

    private bool VerifyCoolingSystemCompatibility()
    {
        return _computer.CoolingSystem is null
            || _computer.Cpu is null
            || _computer.CoolingSystem.SupportedSockets.Contains(_computer.Cpu.Socket);
    }

    private bool VerifyCoolingSystemDissipatedHeatMass()
    {
        return _computer.CoolingSystem is null
            || _computer.Cpu is null
            || _computer.CoolingSystem.MaxDissipatedHeatMass >= _computer.Cpu.HeatDissipation;
    }

    private bool VerifyRamsCompatibility()
{
    return (_computer.Motherboard is null
        || _computer.Motherboard.RamSlotsCount >= _computer.Rams.Count)
        && _computer.Rams.ToList().TrueForAll(VerifyRamCompatibility);
}

    private bool VerifyRamCompatibility(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram, nameof(ram));

        if (_computer.Motherboard is not null)
        {
            if (ram.AvailableXmpProfiles.Count > 0
                && !_computer.Motherboard.Chipset.IsXmpSupported)
            {
                return false;
            }

            bool isFreqSupportedOnMotherboard = ram.SupportedFrequencies.Any(
                t => _computer.Motherboard.Chipset.SupportedFrequencies.Contains(t.Frequency));

            if (!isFreqSupportedOnMotherboard
                || ram.DdrVersion != _computer.Motherboard.SupportedDdrStandard
                || !_computer.Motherboard.AvailableRamFormFactors.Contains(ram.FormFactor))
            {
                return false;
            }
        }

        if (_computer.Cpu is not null)
        {
            bool isXmpSupportedOnCpu = ram.AvailableXmpProfiles
                .ToList()
                .TrueForAll(t => _computer.Cpu.SupportedMemoryFrequencies.Contains(t.Frequency));

            if (ram.AvailableXmpProfiles.Count > 0 && !isXmpSupportedOnCpu)
                return false;

            bool isFreqSupportedOnCpu = ram.SupportedFrequencies.Any(
                t => _computer.Cpu.SupportedMemoryFrequencies.Contains(t.Frequency));

            if (!isFreqSupportedOnCpu)
                return false;
        }

        return true;
    }

    private bool VerifyGpuCompatibility()
    {
        return _computer.Gpu is null
            || _computer.Motherboard is null
            || _computer.Motherboard.AvailablePciELines.Contains(_computer.Gpu.PciEVersion);
    }

    private bool VerifySsdDrivesCompatibility()
    {
        return _computer.SsdDrives
            .ToList()
            .TrueForAll(VerifySsdDriveCompatibility);
    }

    private bool VerifySsdDriveCompatibility(SsdDrive ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd, nameof(ssd));

        if (_computer.Motherboard is null)
            return true;

        if (ssd.ConnectionType == SsdDriveConnectionType.PCIe
            && ssd.PciEVersion is not null
            && !_computer.Motherboard.AvailablePciELines.Contains(ssd.PciEVersion.Value))
        {
            return false;
        }

        bool canConnectedToSata = _computer.Motherboard.SataPortsCount > 0;

        return ssd.ConnectionType != SsdDriveConnectionType.Sata
            || canConnectedToSata;
    }

    private bool VerifyComputerCaseCompatibility()
    {
        if (_computer.Case is null)
            return true;

        if (_computer.Gpu is not null
            && (_computer.Gpu.Width > _computer.Case.MaxGpuWidth
                || _computer.Gpu.Height > _computer.Case.MaxGpuHeight))
        {
            return false;
        }

        if (_computer.Motherboard is not null
            && !_computer.Case.SupportedMotherboardFormFactors.Contains(_computer.Motherboard.FormFactor))
        {
            return false;
        }

        double componentsVolume =
            (_computer.CoolingSystem?.Dimensions.Volume ?? 0) +
            (_computer.Motherboard?.Dimensions.Volume ?? 0);

        return _computer.Case.Dimensions.Volume >= componentsVolume;
    }

    private bool VerifyPowerSupplyCompatibility()
    {
        return _computer.PowerSupply is null
            || _computer.PowerSupply.PeakLoad >= CalcComponentsPowerConsumption();
    }

    private bool VerifyWiFiAdapterCompatibility()
    {
        return _computer.WiFiAdapter is null
            || (!_computer.Motherboard?.HasEmbeddedWiFiModule ?? true);
    }

    private bool VerifyMotherboardPciELines()
    {
        if (_computer.Motherboard is null)
            return true;

        var requiredPciEVersions = _computer.SsdDrives
            .Where(t => t.PciEVersion is not null)
            .Select(t => t.PciEVersion ?? throw new InvalidOperationException())
            .ToList();

        if (_computer.Gpu is not null)
            requiredPciEVersions.Add(_computer.Gpu.PciEVersion);

        if (_computer.WiFiAdapter is not null)
            requiredPciEVersions.Add(_computer.WiFiAdapter.PciEVersion);

        var availablePciELines = _computer.Motherboard.AvailablePciELines.ToList();

        foreach (PciEVersion pciEVersion in requiredPciEVersions)
        {
            if (!availablePciELines.Contains(pciEVersion))
                return false;

            _ = availablePciELines.Remove(pciEVersion);
        }

        return true;
    }

    private bool VerifyMotherboardSataPorts()
    {
        var sataSsd = _computer.SsdDrives
            .Where(t => t.ConnectionType == SsdDriveConnectionType.Sata)
            .ToList();

        return _computer.Motherboard is null
            || _computer.Motherboard.SataPortsCount >= sataSsd.Count;
    }

    private double CalcComponentsPowerConsumption()
    {
        return (_computer.Cpu?.PowerConsumption ?? 0)
            + (_computer.Gpu?.PowerConsumption ?? 0)
            + _computer.Rams.Sum(t => t.PowerConsumption)
            + _computer.SsdDrives.Sum(t => t.PowerConsumption)
            + _computer.HardDisks.Sum(t => t.PowerConsumption);
    }
}
