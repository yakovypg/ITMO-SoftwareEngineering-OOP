using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class XmpProfile
{
    private readonly List<int> _timings;

    public XmpProfile(IEnumerable<int> timings, double voltage, double frequency)
    {
        _timings = timings?.ToList()
            ?? throw new ArgumentNullException(nameof(timings));

        Voltage = voltage;
        Frequency = frequency;
    }

    public double Voltage { get; }
    public double Frequency { get; }

    public IReadOnlyList<int> Timings => _timings;
}
