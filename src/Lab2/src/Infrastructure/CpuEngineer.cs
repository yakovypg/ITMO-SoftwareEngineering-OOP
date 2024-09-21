using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class CpuEngineer
{
    private readonly CpuBuilder _builder;

    public CpuEngineer(CpuBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Cpu ManufactureIntelPentiumG4400()
    {
        return _builder.AddName("Intel Pentium G4400")
            .AddSocket(CpuSocket.LGA1151)
            .AddEmbeddedVideoCoreSupport(true)
            .AddHeatDissipation(54)
            .AddPowerConsumption(54)
            .AddSupportedMemoryFrequency(1.866)
            .AddSupportedMemoryFrequency(2.133)
            .AddCoreFrequency(3.3)
            .AddCoreFrequency(3.3)
            .Build();
    }

    public Cpu ManufactureIntelCoreI58400()
    {
        return _builder.AddName("Intel Core i5-8400")
            .AddSocket(CpuSocket.LGA1151v2)
            .AddEmbeddedVideoCoreSupport(true)
            .AddHeatDissipation(65)
            .AddPowerConsumption(65)
            .AddSupportedMemoryFrequency(2.4)
            .AddSupportedMemoryFrequency(2.6)
            .AddSupportedMemoryFrequency(3.0)
            .AddSupportedMemoryFrequency(3.2)
            .AddCoreFrequency(2.8)
            .AddCoreFrequency(2.8)
            .AddCoreFrequency(2.8)
            .AddCoreFrequency(2.8)
            .AddCoreFrequency(2.8)
            .AddCoreFrequency(2.8)
            .Build();
    }
}
