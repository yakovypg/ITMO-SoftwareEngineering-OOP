using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class RamBuilder
{
    private readonly List<FrequencyVoltage> _supportedFrequencies; // (JEDEC freq, voltage)
    private readonly List<XmpProfile> _availableXmpProfiles;

    private double _sizeGb;
    private RamFormFactor _formFactor;
    private int _ddrVersion;
    private double _powerConsumption;

    public RamBuilder()
    {
        _supportedFrequencies = new();
        _availableXmpProfiles = new();
    }

    public RamBuilder AddSupportedFrequency(FrequencyVoltage frequency)
    {
        ArgumentNullException.ThrowIfNull(frequency, nameof(frequency));

        if (!_supportedFrequencies.Contains(frequency))
            _supportedFrequencies.Add(frequency);

        return this;
    }

    public RamBuilder AddAvailableXmpProfile(XmpProfile availableXmpProfile)
    {
        ArgumentNullException.ThrowIfNull(availableXmpProfile, nameof(availableXmpProfile));

        if (!_availableXmpProfiles.Contains(availableXmpProfile))
            _availableXmpProfiles.Add(availableXmpProfile);

        return this;
    }

    public RamBuilder AddSize(double sizeGb)
    {
        _sizeGb = sizeGb;
        return this;
    }

    public RamBuilder AddFormFactor(RamFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder AddDdrVersion(int ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public RamBuilder AddPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RamBuilder BaseOn(Ram ram)
    {
        ArgumentNullException.ThrowIfNull(ram, nameof(ram));

        _sizeGb = ram.SizeGb;
        _formFactor = ram.FormFactor;
        _ddrVersion = ram.DdrVersion;
        _powerConsumption = ram.PowerConsumption;

        _supportedFrequencies.Clear();
        _supportedFrequencies.AddRange(ram.SupportedFrequencies);

        _availableXmpProfiles.Clear();
        _availableXmpProfiles.AddRange(ram.AvailableXmpProfiles);

        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _supportedFrequencies,
            _availableXmpProfiles,
            _sizeGb,
            _formFactor,
            _ddrVersion,
            _powerConsumption);
    }
}
