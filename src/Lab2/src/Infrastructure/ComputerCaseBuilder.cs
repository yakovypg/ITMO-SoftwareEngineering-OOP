using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class ComputerCaseBuilder
{
    private readonly List<MotherboardFormFactor> _supportedMotherboardFormFactors;

    private double _maxGpuWidth;
    private double _maxGpuHeight;
    private Dimensions _dimensions;

    public ComputerCaseBuilder()
    {
        _supportedMotherboardFormFactors = new();
    }

    public ComputerCaseBuilder AddSupportedMotherboardFormFactor(MotherboardFormFactor formFactor)
    {
        if (!_supportedMotherboardFormFactors.Contains(formFactor))
            _supportedMotherboardFormFactors.Add(formFactor);

        return this;
    }

    public ComputerCaseBuilder AddMaxGpuWidth(double maxGpuWidth)
    {
        _maxGpuWidth = maxGpuWidth;
        return this;
    }

    public ComputerCaseBuilder AddMaxGpuHeight(double maxGpuHeight)
    {
        _maxGpuHeight = maxGpuHeight;
        return this;
    }

    public ComputerCaseBuilder AddDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ComputerCaseBuilder BaseOn(ComputerCase computerCase)
    {
        ArgumentNullException.ThrowIfNull(computerCase, nameof(computerCase));

        _maxGpuWidth = computerCase.MaxGpuWidth;
        _maxGpuHeight = computerCase.MaxGpuHeight;
        _dimensions = computerCase.Dimensions;

        _supportedMotherboardFormFactors.Clear();
        _supportedMotherboardFormFactors.AddRange(computerCase.SupportedMotherboardFormFactors);

        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _supportedMotherboardFormFactors,
            _maxGpuWidth,
            _maxGpuHeight,
            _dimensions);
    }
}
