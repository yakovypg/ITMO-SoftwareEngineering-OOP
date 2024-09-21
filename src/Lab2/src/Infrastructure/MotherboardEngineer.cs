using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class MotherboardEngineer
{
    private readonly MotherboardBuilder _builder;

    public MotherboardEngineer(MotherboardBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Motherboard ManufactureAFOXIH110D4MA2()
    {
        return _builder.AddSocket(CpuSocket.LGA1151)
            .AddSataPortsCount(4)
            .AddChipset(new Chipset(true, new double[] { 1.866, 2.133 }))
            .AddSupportedDdrStandard(4)
            .AddFormFactor(MotherboardFormFactor.MiniDTX)
            .AddBios(new Bios(new string[] { "Intel Pentium G4400" }, BiosType.IntelBios, "14.11.2013"))
            .AddEmbeddedWiFiModuleSupport(false)
            .AddAvailableRamFormFactor(RamFormFactor.DIMM)
            .AddAvailableRamFormFactor(RamFormFactor.DIMM)
            .AddAvailablePciELine(PciEVersion.PCIe2)
            .Build();
    }

    public Motherboard ManufactureASRockH310CMDVS()
    {
        return _builder.AddSocket(CpuSocket.LGA1151v2)
            .AddSataPortsCount(4)
            .AddChipset(new Chipset(true, new double[] { 2.6, 2.4, 3.2 }))
            .AddSupportedDdrStandard(4)
            .AddFormFactor(MotherboardFormFactor.MicroATX)
            .AddBios(new Bios(new string[] { "Intel Core i5-8400" }, BiosType.IntelBios, "09.10.2015"))
            .AddEmbeddedWiFiModuleSupport(true)
            .AddAvailableRamFormFactor(RamFormFactor.DIMM)
            .AddAvailableRamFormFactor(RamFormFactor.DIMM)
            .AddAvailablePciELine(PciEVersion.PCIe2)
            .AddAvailablePciELine(PciEVersion.PCIe3)
            .Build();
    }
}
