using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IComputerComponentsRepository
{
    IReadOnlyList<Motherboard> Motherboards { get; }
    IReadOnlyList<Cpu> Cpus { get; }
    IReadOnlyList<CpuCoolingSystem> CoolingSystems { get; }
    IReadOnlyList<Gpu> Gpus { get; }
    IReadOnlyList<ComputerCase> ComputerCases { get; }
    IReadOnlyList<PowerSupply> PowerSupplies { get; }
    IReadOnlyList<WiFiAdapter> WiFiAdapters { get; }
    IReadOnlyList<SsdDrive> SsdDrives { get; }
    IReadOnlyList<HardDisk> HardDisks { get; }
    IReadOnlyList<Ram> Rams { get; }

    void AddMotherboard(Motherboard motherboard);
    void AddCpu(Cpu cpu);
    void AddCoolingSystem(CpuCoolingSystem coolingSystem);
    void AddGpu(Gpu gpu);
    void AddComputerCase(ComputerCase computerCase);
    void AddPowerSupply(PowerSupply powerSupply);
    void AddWiFiAdapter(WiFiAdapter wifiAdapter);
    void AddSsdDrive(SsdDrive ssd);
    void AddHardDisk(HardDisk hardDisk);
    void AddRam(Ram ram);
}
