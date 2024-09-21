using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class PowerSupplyBuilder
{
    private double _peakLoad;
    private double _recommendedMaxLoad;

    public PowerSupplyBuilder AddPeakLoad(double peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public PowerSupplyBuilder AddRecommendedMaxLoad(double recommendedMaxLoad)
    {
        _recommendedMaxLoad = recommendedMaxLoad;
        return this;
    }

    public PowerSupplyBuilder BaseOn(PowerSupply powerSupply)
    {
        ArgumentNullException.ThrowIfNull(powerSupply, nameof(powerSupply));

        _peakLoad = powerSupply.PeakLoad;
        _recommendedMaxLoad = powerSupply.RecommendedMaxLoad;

        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(_peakLoad, _recommendedMaxLoad);
    }
}
