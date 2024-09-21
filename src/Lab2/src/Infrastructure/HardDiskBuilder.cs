using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class HardDiskBuilder
{
    private double _sizeGb;
    private int _speed;
    private double _powerConsumption;

    public HardDiskBuilder AddSize(double sizeGb)
    {
        _sizeGb = sizeGb;
        return this;
    }

    public HardDiskBuilder AddSpeed(int speed)
    {
        _speed = speed;
        return this;
    }

    public HardDiskBuilder AddPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HardDiskBuilder BaseOn(HardDisk hardDisk)
    {
        ArgumentNullException.ThrowIfNull(hardDisk, nameof(hardDisk));

        _sizeGb = hardDisk.SizeGb;
        _speed = hardDisk.Speed;
        _powerConsumption = hardDisk.PowerConsumption;

        return this;
    }

    public HardDisk Build()
    {
        return new HardDisk(_sizeGb, _speed, _powerConsumption);
    }
}
