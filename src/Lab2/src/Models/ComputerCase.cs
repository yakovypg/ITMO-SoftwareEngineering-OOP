using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerCase
{
    private readonly List<MotherboardFormFactor> _supportedMotherboardFormFactors;

    public ComputerCase(
        IEnumerable<MotherboardFormFactor> supportedMotherboardFormFactors,
        double maxGpuWidth,
        double maxGpuHeight,
        Dimensions dimensions)
    {
        _supportedMotherboardFormFactors = supportedMotherboardFormFactors?.ToList()
            ?? throw new ArgumentNullException(nameof(supportedMotherboardFormFactors));

        MaxGpuWidth = maxGpuWidth;
        MaxGpuHeight = maxGpuHeight;
        Dimensions = dimensions;
    }

    public double MaxGpuWidth { get; }
    public double MaxGpuHeight { get; }
    public Dimensions Dimensions { get; }

    public IReadOnlyList<MotherboardFormFactor> SupportedMotherboardFormFactors => _supportedMotherboardFormFactors;
}
