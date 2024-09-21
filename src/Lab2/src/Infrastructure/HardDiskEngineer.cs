using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class HardDiskEngineer
{
    private readonly HardDiskBuilder _builder;

    public HardDiskEngineer(HardDiskBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public HardDisk ManufactureSeagateBarraCuda()
    {
        return _builder.AddSize(2 * 1024)
            .AddSpeed(7200)
            .AddPowerConsumption(3.7)
            .Build();
    }
}
