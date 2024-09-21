using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class CpuCoolingSystemBuilder
{
    private readonly List<CpuSocket> _supportedSockets;

    private Dimensions _dimensions;
    private double _maxDissipatedHeatMass;

    public CpuCoolingSystemBuilder()
    {
        _supportedSockets = new();
    }

    public CpuCoolingSystemBuilder AddSupportedSocket(CpuSocket socket)
    {
        if (!_supportedSockets.Contains(socket))
            _supportedSockets.Add(socket);

        return this;
    }

    public CpuCoolingSystemBuilder AddDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public CpuCoolingSystemBuilder AddMaxDissipatedHeatMass(double maxDissipatedHeatMass)
    {
        _maxDissipatedHeatMass = maxDissipatedHeatMass;
        return this;
    }

    public CpuCoolingSystemBuilder BaseOn(CpuCoolingSystem coolingSystem)
    {
        ArgumentNullException.ThrowIfNull(coolingSystem, nameof(coolingSystem));

        _dimensions = coolingSystem.Dimensions;
        _maxDissipatedHeatMass = coolingSystem.MaxDissipatedHeatMass;

        _supportedSockets.Clear();
        _supportedSockets.AddRange(coolingSystem.SupportedSockets);

        return this;
    }

    public CpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _supportedSockets,
            _dimensions,
            _maxDissipatedHeatMass);
    }
}
