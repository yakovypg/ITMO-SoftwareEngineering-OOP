using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class MotherboardBuilder
{
    private readonly List<RamFormFactor> _availableRamFormFactors;
    private readonly List<PciEVersion> _availablePciELines;

    private CpuSocket _socket;
    private int _sataPortsCount;
    private Chipset? _chipset;
    private int _supportedDdrStandard;
    private MotherboardFormFactor _formFactor;
    private Bios? _bios;
    private bool _hasEmbeddedWiFiModule;

    public MotherboardBuilder()
    {
        _availableRamFormFactors = new();
        _availablePciELines = new();
    }

    public MotherboardBuilder AddAvailableRamFormFactor(RamFormFactor ramFormFactor)
    {
        if (!_availableRamFormFactors.Contains(ramFormFactor))
            _availableRamFormFactors.Add(ramFormFactor);

        return this;
    }

    public MotherboardBuilder AddAvailablePciELine(PciEVersion pciEVersion)
    {
        if (!_availablePciELines.Contains(pciEVersion))
            _availablePciELines.Add(pciEVersion);

        return this;
    }

    public MotherboardBuilder AddSocket(CpuSocket socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder AddSataPortsCount(int sataPortsCount)
    {
        _sataPortsCount = sataPortsCount;
        return this;
    }

    public MotherboardBuilder AddChipset(Chipset chipset)
    {
        ArgumentNullException.ThrowIfNull(chipset, nameof(chipset));

        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder AddSupportedDdrStandard(int supportedDdrStandard)
    {
        _supportedDdrStandard = supportedDdrStandard;
        return this;
    }

    public MotherboardBuilder AddFormFactor(MotherboardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder AddBios(Bios bios)
    {
        ArgumentNullException.ThrowIfNull(bios, nameof(bios));

        _bios = bios;
        return this;
    }

    public MotherboardBuilder AddEmbeddedWiFiModuleSupport(bool hasEmbeddedWiFiModule)
    {
        _hasEmbeddedWiFiModule = hasEmbeddedWiFiModule;
        return this;
    }

    public MotherboardBuilder BaseOn(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard, nameof(motherboard));

        _socket = motherboard.Socket;
        _sataPortsCount = motherboard.SataPortsCount;
        _chipset = motherboard.Chipset;
        _supportedDdrStandard = motherboard.SupportedDdrStandard;
        _formFactor = motherboard.FormFactor;
        _bios = motherboard.Bios;
        _hasEmbeddedWiFiModule = motherboard.HasEmbeddedWiFiModule;

        _availableRamFormFactors.Clear();
        _availableRamFormFactors.AddRange(motherboard.AvailableRamFormFactors);

        _availablePciELines.Clear();
        _availablePciELines.AddRange(motherboard.AvailablePciELines);

        return this;
    }

    public Motherboard Build()
    {
        if (_chipset is null)
            throw new MissingComponentException(typeof(Chipset));

        if (_bios is null)
            throw new MissingComponentException(typeof(Bios));

        return new Motherboard(
            _socket,
            _availablePciELines,
            _sataPortsCount,
            _chipset,
            _supportedDdrStandard,
            _availableRamFormFactors,
            _formFactor,
            _bios,
            _hasEmbeddedWiFiModule);
    }
}
