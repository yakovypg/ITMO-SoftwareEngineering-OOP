using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class CpuBuilder
{
    private readonly List<double> _coresFrequencies;
    private readonly List<double> _supportedMemoryFrequencies;

    private CpuSocket _socket;
    private bool _hasEmbeddedVideoCore;
    private double _heatDissipation;
    private double _powerConsumption;
    private string _name = string.Empty;

    public CpuBuilder()
    {
        _coresFrequencies = new();
        _supportedMemoryFrequencies = new();
    }

    public CpuBuilder AddCoreFrequency(double frequency)
    {
        if (!_coresFrequencies.Contains(frequency))
            _coresFrequencies.Add(frequency);

        return this;
    }

    public CpuBuilder AddSupportedMemoryFrequency(double frequency)
    {
        if (!_supportedMemoryFrequencies.Contains(frequency))
            _supportedMemoryFrequencies.Add(frequency);

        return this;
    }

    public CpuBuilder AddSocket(CpuSocket socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder AddEmbeddedVideoCoreSupport(bool hasEmbeddedVideoCore)
    {
        _hasEmbeddedVideoCore = hasEmbeddedVideoCore;
        return this;
    }

    public CpuBuilder AddHeatDissipation(double heatDissipation)
    {
        _heatDissipation = heatDissipation;
        return this;
    }

    public CpuBuilder AddPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public CpuBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder BaseOn(Cpu cpu)
    {
        ArgumentNullException.ThrowIfNull(cpu, nameof(cpu));

        _socket = cpu.Socket;
        _hasEmbeddedVideoCore = cpu.HasEmbeddedVideoCore;
        _heatDissipation = cpu.HeatDissipation;
        _powerConsumption = cpu.PowerConsumption;

        _coresFrequencies.Clear();
        _supportedMemoryFrequencies.Clear();

        _coresFrequencies.AddRange(cpu.CoresFrequencies);
        _coresFrequencies.AddRange(cpu.SupportedMemoryFrequencies);

        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _coresFrequencies,
            _supportedMemoryFrequencies,
            _socket,
            _hasEmbeddedVideoCore,
            _heatDissipation,
            _powerConsumption,
            _name);
    }
}
