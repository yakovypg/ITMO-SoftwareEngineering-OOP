using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Ram
{
    private readonly List<FrequencyVoltage> _supportedFrequencies; // (JEDEC freq, voltage)
    private readonly List<XmpProfile> _availableXmpProfiles;

    public Ram(
        IEnumerable<FrequencyVoltage> supportedFrequencies,
        IEnumerable<XmpProfile> availableXmpProfiles,
        double sizeGb,
        RamFormFactor formFactor,
        int ddrVersion,
        double powerConsumption)
    {
        _supportedFrequencies = supportedFrequencies?.ToList()
            ?? throw new ArgumentNullException(nameof(supportedFrequencies));

        _availableXmpProfiles = availableXmpProfiles?.ToList()
            ?? throw new ArgumentNullException(nameof(availableXmpProfiles));

        SizeGb = sizeGb;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public double SizeGb { get; }
    public RamFormFactor FormFactor { get; }
    public int DdrVersion { get; }
    public double PowerConsumption { get; }

    public IReadOnlyList<FrequencyVoltage> SupportedFrequencies => _supportedFrequencies;
    public IReadOnlyList<XmpProfile> AvailableXmpProfiles => _availableXmpProfiles;
}
