using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Cpu
{
    private readonly List<double> _coresFrequencies;
    private readonly List<double> _supportedMemoryFrequencies;

    public Cpu(
        IEnumerable<double> coresFrequencies,
        IEnumerable<double> supportedMemoryFrequencies,
        CpuSocket socket,
        bool hasEmbeddedVideoCore,
        double heatDissipation,
        double powerConsumption,
        string name)
    {
        _coresFrequencies = coresFrequencies?.ToList()
            ?? throw new ArgumentNullException(nameof(coresFrequencies));

        _supportedMemoryFrequencies = supportedMemoryFrequencies?.ToList()
            ?? throw new ArgumentNullException(nameof(supportedMemoryFrequencies));

        Socket = socket;
        HasEmbeddedVideoCore = hasEmbeddedVideoCore;
        HeatDissipation = heatDissipation;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public CpuSocket Socket { get; }
    public bool HasEmbeddedVideoCore { get; }
    public double HeatDissipation { get; }
    public double PowerConsumption { get; }
    public string Name { get; }

    public int CoresCount => _coresFrequencies.Count;
    public IReadOnlyList<double> CoresFrequencies => _coresFrequencies;
    public IReadOnlyList<double> SupportedMemoryFrequencies => _supportedMemoryFrequencies;
}
