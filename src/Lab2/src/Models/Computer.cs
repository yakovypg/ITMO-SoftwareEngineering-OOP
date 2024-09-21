using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer
{
    private readonly List<SsdDrive> _ssdDrives;
    private readonly List<HardDisk> _hardDisks;
    private readonly List<Ram> _rams;

    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private CpuCoolingSystem? _coolingSystem;
    private Gpu? _gpu;
    private ComputerCase? _case;
    private PowerSupply? _powerSupply;
    private WiFiAdapter? _wifiAdapter;

    public Computer()
    {
        _ssdDrives = new();
        _hardDisks = new();
        _rams = new();
    }

    public Motherboard? Motherboard
    {
        get => _motherboard;
        set
        {
            if (!ComputerComponentsService.Repository.Motherboards.Contains(value))
                throw new ComponentNotRegisteredException();

            _motherboard = value;
        }
    }

    public Cpu? Cpu
    {
        get => _cpu;
        set
        {
            if (!ComputerComponentsService.Repository.Cpus.Contains(value))
                throw new ComponentNotRegisteredException();

            _cpu = value;
        }
    }

    public CpuCoolingSystem? CoolingSystem
    {
        get => _coolingSystem;
        set
        {
            if (!ComputerComponentsService.Repository.CoolingSystems.Contains(value))
                throw new ComponentNotRegisteredException();

            _coolingSystem = value;
        }
    }

    public Gpu? Gpu
    {
        get => _gpu;
        set
        {
            if (!ComputerComponentsService.Repository.Gpus.Contains(value))
                throw new ComponentNotRegisteredException();

            _gpu = value;
        }
    }

    public ComputerCase? Case
    {
        get => _case;
        set
        {
            if (!ComputerComponentsService.Repository.ComputerCases.Contains(value))
                throw new ComponentNotRegisteredException();

            _case = value;
        }
    }

    public PowerSupply? PowerSupply
    {
        get => _powerSupply;
        set
        {
            if (!ComputerComponentsService.Repository.PowerSupplies.Contains(value))
                throw new ComponentNotRegisteredException();

            _powerSupply = value;
        }
    }

    public WiFiAdapter? WiFiAdapter
    {
        get => _wifiAdapter;
        set
        {
            if (!ComputerComponentsService.Repository.WiFiAdapters.Contains(value))
                throw new ComponentNotRegisteredException();

            _wifiAdapter = value;
        }
    }

    public IReadOnlyList<SsdDrive> SsdDrives => _ssdDrives;
    public IReadOnlyList<HardDisk> HardDisks => _hardDisks;
    public IReadOnlyList<Ram> Rams => _rams;

    public void AddSsdDrive(SsdDrive ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd, nameof(ssd));

        if (!ComputerComponentsService.Repository.SsdDrives.Contains(ssd))
            throw new ComponentNotRegisteredException();

        if (!_ssdDrives.Contains(ssd))
            _ssdDrives.Add(ssd);
    }

    public void AddHardDisk(HardDisk hardDisk)
    {
        ArgumentNullException.ThrowIfNull(hardDisk, nameof(hardDisk));

        if (!ComputerComponentsService.Repository.HardDisks.Contains(hardDisk))
            throw new ComponentNotRegisteredException();

        if (!_hardDisks.Contains(hardDisk))
            _hardDisks.Add(hardDisk);
    }

    public void AddRam(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram, nameof(ram));

        if (!ComputerComponentsService.Repository.Rams.Contains(ram))
            throw new ComponentNotRegisteredException();

        if (!_rams.Contains(ram))
            _rams.Add(ram);
    }
}
