using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class PowerSupplyEngineer
{
    private readonly PowerSupplyBuilder _builder;

    public PowerSupplyEngineer(PowerSupplyBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public PowerSupply ManufactureExeGateUN350()
    {
        return _builder.AddPeakLoad(350)
            .AddRecommendedMaxLoad(260)
            .Build();
    }

    public PowerSupply ManufactureExeGateTY600()
    {
        return _builder.AddPeakLoad(600)
            .AddRecommendedMaxLoad(500)
            .Build();
    }

    public PowerSupply ManufactureCougarBXM1200()
    {
        return _builder.AddPeakLoad(1200)
            .AddRecommendedMaxLoad(1000)
            .Build();
    }
}
