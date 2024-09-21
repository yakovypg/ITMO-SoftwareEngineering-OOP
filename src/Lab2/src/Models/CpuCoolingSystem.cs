using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class CpuCoolingSystem
{
    private readonly List<CpuSocket> _supportedSockets;

    public CpuCoolingSystem(
        IEnumerable<CpuSocket> supportedSockets,
        Dimensions dimensions,
        double maxDissipatedHeatMass)
    {
        _supportedSockets = supportedSockets?.ToList()
            ?? throw new ArgumentNullException(nameof(supportedSockets));

        Dimensions = dimensions;
        MaxDissipatedHeatMass = maxDissipatedHeatMass;
    }

    public Dimensions Dimensions { get; }
    public double MaxDissipatedHeatMass { get; }

    public IReadOnlyList<CpuSocket> SupportedSockets => _supportedSockets;
}
