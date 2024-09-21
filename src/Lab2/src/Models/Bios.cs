using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Bios
{
    private readonly List<string> _supportedCpus;

    public Bios(IEnumerable<string> supportedCpus, BiosType biosType, string version)
    {
        _supportedCpus = supportedCpus?.ToList()
            ?? throw new ArgumentNullException(nameof(supportedCpus));

        BiosType = biosType;
        Version = version ?? throw new ArgumentNullException(nameof(version));
    }

    public BiosType BiosType { get; }
    public string Version { get; }

    public IReadOnlyList<string> SupportedCpus => _supportedCpus;
}
