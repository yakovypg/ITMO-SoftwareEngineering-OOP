using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Chipset
{
    private readonly List<double> _supportedFrequencies;

    public Chipset(bool isXmpSupported, IEnumerable<double> supportedFrequencies)
    {
        IsXmpSupported = isXmpSupported;

        _supportedFrequencies = supportedFrequencies?.ToList()
            ?? throw new ArgumentNullException(nameof(supportedFrequencies));
    }

    public bool IsXmpSupported { get; }
    public IReadOnlyList<double> SupportedFrequencies => _supportedFrequencies;
}
