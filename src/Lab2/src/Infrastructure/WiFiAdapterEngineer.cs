using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class WiFiAdapterEngineer
{
    private readonly WiFiAdapterBuilder _builder;

    public WiFiAdapterEngineer(WiFiAdapterBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public WiFiAdapter ManufactureTPLinkArcherT2E()
    {
        return _builder.AddWiFiVersion(5)
            .AddEmbeddedBluetoothModuleSupport(false)
            .AddPciEVersion(Enums.PciEVersion.PCIe4)
            .AddPowerConsumption(0.5)
            .Build();
    }
}
