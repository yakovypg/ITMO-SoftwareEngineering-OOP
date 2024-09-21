using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class ComputerComponentsRepository : IComputerComponentsRepository
{
    private readonly List<Motherboard> _motherboards;
    private readonly List<Cpu> _cpus;
    private readonly List<CpuCoolingSystem> _coolingSystems;
    private readonly List<Gpu> _gpus;
    private readonly List<ComputerCase> _computerCases;
    private readonly List<PowerSupply> _powerSupplies;
    private readonly List<WiFiAdapter> _wifiAdapters;
    private readonly List<SsdDrive> _ssdDrives;
    private readonly List<HardDisk> _hardDisks;
    private readonly List<Ram> _rams;

    public ComputerComponentsRepository()
    {
        _motherboards = new();
        _cpus = new();
        _coolingSystems = new();
        _gpus = new();
        _computerCases = new();
        _powerSupplies = new();
        _wifiAdapters = new();
        _ssdDrives = new();
        _hardDisks = new();
        _rams = new();
    }

    public IReadOnlyList<Motherboard> Motherboards => _motherboards;
    public IReadOnlyList<Cpu> Cpus => _cpus;
    public IReadOnlyList<CpuCoolingSystem> CoolingSystems => _coolingSystems;
    public IReadOnlyList<Gpu> Gpus => _gpus;
    public IReadOnlyList<ComputerCase> ComputerCases => _computerCases;
    public IReadOnlyList<PowerSupply> PowerSupplies => _powerSupplies;
    public IReadOnlyList<WiFiAdapter> WiFiAdapters => _wifiAdapters;
    public IReadOnlyList<SsdDrive> SsdDrives => _ssdDrives;
    public IReadOnlyList<HardDisk> HardDisks => _hardDisks;
    public IReadOnlyList<Ram> Rams => _rams;

    public void AddMotherboard(Motherboard motherboard)
    {
        ArgumentNullException.ThrowIfNull(motherboard, nameof(motherboard));

        if (!_motherboards.Contains(motherboard))
            _motherboards.Add(motherboard);
    }

    public void AddCpu(Cpu cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu, nameof(cpu));

        if (!_cpus.Contains(cpu))
            _cpus.Add(cpu);
    }

    public void AddCoolingSystem(CpuCoolingSystem coolingSystem)
    {
        ArgumentNullException.ThrowIfNull(coolingSystem, nameof(coolingSystem));

        if (!_coolingSystems.Contains(coolingSystem))
            _coolingSystems.Add(coolingSystem);
    }

    public void AddGpu(Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(gpu, nameof(gpu));

        if (!_gpus.Contains(gpu))
            _gpus.Add(gpu);
    }

    public void AddComputerCase(ComputerCase computerCase)
    {
        ArgumentNullException.ThrowIfNull(computerCase, nameof(computerCase));

        if (!_computerCases.Contains(computerCase))
            _computerCases.Add(computerCase);
    }

    public void AddPowerSupply(PowerSupply powerSupply)
    {
        ArgumentNullException.ThrowIfNull(powerSupply, nameof(powerSupply));

        if (!_powerSupplies.Contains(powerSupply))
            _powerSupplies.Add(powerSupply);
    }

    public void AddWiFiAdapter(WiFiAdapter wifiAdapter)
    {
        ArgumentNullException.ThrowIfNull(wifiAdapter, nameof(wifiAdapter));

        if (!_wifiAdapters.Contains(wifiAdapter))
            _wifiAdapters.Add(wifiAdapter);
    }

    public void AddSsdDrive(SsdDrive ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd, nameof(ssd));

        if (!_ssdDrives.Contains(ssd))
            _ssdDrives.Add(ssd);
    }

    public void AddHardDisk(HardDisk hardDisk)
    {
        ArgumentNullException.ThrowIfNull(hardDisk, nameof(hardDisk));

        if (!_hardDisks.Contains(hardDisk))
            _hardDisks.Add(hardDisk);
    }

    public void AddRam(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram, nameof(ram));

        if (!_rams.Contains(ram))
            _rams.Add(ram);
    }
}
