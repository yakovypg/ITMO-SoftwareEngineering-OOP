using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class RamEngineer
{
    private readonly RamBuilder _builder;

    public RamEngineer(RamBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Ram ManufactureKingstonFury()
    {
        return _builder.AddSize(8)
            .AddFormFactor(RamFormFactor.DIMM)
            .AddDdrVersion(4)
            .AddPowerConsumption(1.3)
            .AddSupportedFrequency(new FrequencyVoltage(3.2, 1.35))
            .AddAvailableXmpProfile(new XmpProfile(new int[] { 15, 17, 17 }, 1.3, 3.0))
            .AddAvailableXmpProfile(new XmpProfile(new int[] { 16, 18, 18 }, 1.35, 3.2))
            .Build();
    }

    public Ram ManufacturePatriotViper3()
    {
        return _builder.AddSize(8)
            .AddFormFactor(RamFormFactor.DIMM)
            .AddDdrVersion(3)
            .AddPowerConsumption(1.0)
            .AddSupportedFrequency(new FrequencyVoltage(1.866, 1.5))
            .AddAvailableXmpProfile(new XmpProfile(new int[] { 10, 11, 10, 30 }, 1.5, 1.866))
            .Build();
    }
}
