using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class CpuCoolingSystemEngineer
{
    private readonly CpuCoolingSystemBuilder _builder;

    public CpuCoolingSystemEngineer(CpuCoolingSystemBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public CpuCoolingSystem ManufactureCoolTY50()
    {
        return _builder.AddDimensions(new Dimensions(60, 100, 90))
            .AddMaxDissipatedHeatMass(50)
            .AddSupportedSocket(CpuSocket.LGA1150)
            .AddSupportedSocket(CpuSocket.LGA1151)
            .AddSupportedSocket(CpuSocket.LGA1151v2)
            .Build();
    }

    public CpuCoolingSystem ManufactureDeepCoolAK620()
    {
        return _builder.AddDimensions(new Dimensions(129, 160, 138))
            .AddMaxDissipatedHeatMass(260)
            .AddSupportedSocket(CpuSocket.LGA1150)
            .AddSupportedSocket(CpuSocket.LGA1151)
            .AddSupportedSocket(CpuSocket.LGA1151v2)
            .AddSupportedSocket(CpuSocket.LGA1155)
            .AddSupportedSocket(CpuSocket.LGA2011)
            .AddSupportedSocket(CpuSocket.LGA20113)
            .AddSupportedSocket(CpuSocket.LGA2066)
            .Build();
    }
}
