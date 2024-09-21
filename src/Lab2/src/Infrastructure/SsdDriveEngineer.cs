using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class SsdDriveEngineer
{
    private readonly SsdDriveBuilder _builder;

    public SsdDriveEngineer(SsdDriveBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public SsdDrive ManufactureApacerAS350Panther()
    {
        return _builder.AddSize(256)
            .AddMaxSpeed(560)
            .AddPowerConsumption(1.45)
            .Build();
    }
}
