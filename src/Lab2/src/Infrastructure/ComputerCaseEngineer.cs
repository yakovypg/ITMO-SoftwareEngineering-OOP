using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class ComputerCaseEngineer
{
    private readonly ComputerCaseBuilder _builder;

    public ComputerCaseEngineer(ComputerCaseBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public ComputerCase ManufactureSmallCase()
    {
        return _builder.AddDimensions(new Dimensions(200, 100, 200))
            .AddMaxGpuWidth(0)
            .AddMaxGpuHeight(0)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.MiniITX)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.MiniDTX)
            .Build();
    }

    public ComputerCase ManufactureStandardCase()
    {
        return _builder.AddDimensions(new Dimensions(200, 413, 420))
            .AddMaxGpuWidth(120)
            .AddMaxGpuHeight(310)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.MiniITX)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.MiniDTX)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.FlexATX)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.MicroATX)
            .Build();
    }

    public ComputerCase ManufactureBigCase()
    {
        return _builder.AddDimensions(new Dimensions(250, 500, 450))
            .AddMaxGpuWidth(120)
            .AddMaxGpuHeight(310)
            .AddSupportedMotherboardFormFactor(MotherboardFormFactor.NLX)
            .Build();
    }
}
