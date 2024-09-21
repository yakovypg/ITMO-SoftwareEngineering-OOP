using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class GpuEngineer
{
    private readonly GpuBuilder _builder;

    public GpuEngineer(GpuBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Gpu ManufactureKFA2GeForce210()
    {
        return _builder.AddHeight(168)
            .AddWidth(27)
            .AddMemory(1)
            .AddPciEVersion(PciEVersion.PCIe2)
            .AddChipFrequency(0.52)
            .AddPowerConsumption(300)
            .Build();
    }

    public Gpu ManufactureGeForceRTX2060()
    {
        return _builder.AddHeight(242)
             .AddWidth(53)
             .AddMemory(6)
             .AddPciEVersion(PciEVersion.PCIe3)
             .AddChipFrequency(1.365)
             .AddPowerConsumption(500)
             .Build();
    }
}
