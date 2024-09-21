using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class GpuBuilder
{
    private double _height;
    private double _width;
    private double _memoryGb;
    private PciEVersion _pciEVersion;
    private double _chipFrequency;
    private double _powerConsumption;

    public GpuBuilder AddHeight(double height)
    {
        _height = height;
        return this;
    }

    public GpuBuilder AddWidth(double width)
    {
        _width = width;
        return this;
    }

    public GpuBuilder AddMemory(double memoryGb)
    {
        _memoryGb = memoryGb;
        return this;
    }

    public GpuBuilder AddPciEVersion(PciEVersion pciEVersion)
    {
        _pciEVersion = pciEVersion;
        return this;
    }

    public GpuBuilder AddChipFrequency(double chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GpuBuilder AddPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public GpuBuilder BaseOn(Gpu gpu)
    {
        ArgumentNullException.ThrowIfNull(gpu, nameof(gpu));

        _height = gpu.Height;
        _width = gpu.Width;
        _memoryGb = gpu.MemoryGb;
        _pciEVersion = gpu.PciEVersion;
        _chipFrequency = gpu.ChipFrequency;
        _powerConsumption = gpu.PowerConsumption;

        return this;
    }

    public Gpu Build()
    {
        return new Gpu(
            _height,
            _width,
            _memoryGb,
            _pciEVersion,
            _chipFrequency,
            _powerConsumption);
    }
}
