using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class ComputerConstructor
{
    private readonly Computer _computer;

    public ComputerConstructor()
    {
        _computer = new();
    }

    public ComputerConstructor AddMotherboard(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard, nameof(motherboard));
        _computer.Motherboard = motherboard;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddCpu(Cpu cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu, nameof(cpu));
        _computer.Cpu = cpu;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddCoolingSystem(CpuCoolingSystem coolingSystem)
    {
        ArgumentNullException.ThrowIfNull(coolingSystem, nameof(coolingSystem));
        _computer.CoolingSystem = coolingSystem;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddGpu(Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(gpu, nameof(gpu));
        _computer.Gpu = gpu;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddPowerSupply(PowerSupply powerSupply)
    {
        ArgumentNullException.ThrowIfNull(powerSupply, nameof(powerSupply));
        _computer.PowerSupply = powerSupply;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddCase(ComputerCase computerCase)
    {
        ArgumentNullException.ThrowIfNull(computerCase, nameof(computerCase));
        _computer.Case = computerCase;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddWiFiAdapter(WiFiAdapter adapter)
    {
        ArgumentNullException.ThrowIfNull(adapter, nameof(adapter));
        _computer.WiFiAdapter = adapter;

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddSsdDrive(SsdDrive ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd, nameof(ssd));
        _computer.AddSsdDrive(ssd);

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddHardDisk(HardDisk hardDisk)
    {
        ArgumentNullException.ThrowIfNull(hardDisk, nameof(hardDisk));
        _computer.AddHardDisk(hardDisk);

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor AddRam(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram, nameof(ram));
        _computer.AddRam(ram);

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public ComputerConstructor BaseOnPlatform(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer, nameof(computer));

        if (computer.Motherboard is not null)
            _computer.Motherboard ??= computer.Motherboard;

        if (computer.Cpu is not null)
            _computer.Cpu ??= computer.Cpu;

        if (computer.CoolingSystem is not null)
            _computer.CoolingSystem ??= computer.CoolingSystem;

        if (computer.Gpu is not null)
            _computer.Gpu ??= computer.Gpu;

        if (computer.Case is not null)
            _computer.Case ??= computer.Case;

        if (computer.PowerSupply is not null)
            _computer.PowerSupply ??= computer.PowerSupply;

        if (computer.WiFiAdapter is not null)
            _computer.WiFiAdapter ??= computer.WiFiAdapter;

        if (computer.SsdDrives.Count > 0 && _computer.SsdDrives.Count == 0)
        {
            foreach (SsdDrive ssd in computer.SsdDrives)
            {
                _computer.AddSsdDrive(ssd);
            }
        }

        if (computer.HardDisks.Count > 0 && _computer.HardDisks.Count == 0)
        {
            foreach (HardDisk hardDisk in computer.HardDisks)
            {
                _computer.AddHardDisk(hardDisk);
            }
        }

        if (computer.Rams.Count > 0 && _computer.Rams.Count == 0)
        {
            foreach (Ram ram in computer.Rams)
            {
                _computer.AddRam(ram);
            }
        }

        new ComputerInspector(_computer).InspectAllComponents();
        return this;
    }

    public Computer Build()
    {
        new ComputerInspector(_computer).Inspect();
        return _computer;
    }
}
