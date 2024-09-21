using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class SsdDriveBuilder
{
    private double _sizeGb;
    private int _maxSpeed;
    private double _powerConsumption;
    private PciEVersion? _pciEVersion;

    public SsdDriveBuilder AddSize(double sizeGb)
    {
        _sizeGb = sizeGb;
        return this;
    }

    public SsdDriveBuilder AddMaxSpeed(int maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public SsdDriveBuilder AddPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SsdDriveBuilder AddPciEVersion(PciEVersion pciEVersion)
    {
        _pciEVersion = pciEVersion;
        return this;
    }

    public SsdDriveBuilder BaseOn(SsdDrive ssd)
    {
        ArgumentNullException.ThrowIfNull(ssd, nameof(ssd));

        _sizeGb = ssd.SizeGb;
        _maxSpeed = ssd.MaxSpeed;
        _powerConsumption = ssd.PowerConsumption;
        _pciEVersion = ssd.PciEVersion;

        return this;
    }

    public SsdDrive Build()
    {
        return new SsdDrive(
            _sizeGb,
            _maxSpeed,
            _powerConsumption,
            _pciEVersion);
    }
}
