using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;

public class WiFiAdapterBuilder
{
    private int _wiFiVersion;
    private bool _hasEmbeddedBluetoothModule;
    private PciEVersion _pciEVersion;
    private double _powerConsumption;

    public WiFiAdapterBuilder AddWiFiVersion(int version)
    {
        _wiFiVersion = version;
        return this;
    }

    public WiFiAdapterBuilder AddEmbeddedBluetoothModuleSupport(bool hasEmbeddedBluetoothModule)
    {
        _hasEmbeddedBluetoothModule = hasEmbeddedBluetoothModule;
        return this;
    }

    public WiFiAdapterBuilder AddPciEVersion(PciEVersion pciEVersion)
    {
        _pciEVersion = pciEVersion;
        return this;
    }

    public WiFiAdapterBuilder AddPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapterBuilder BaseOn(WiFiAdapter adapter)
    {
        ArgumentNullException.ThrowIfNull(adapter, nameof(adapter));

        _wiFiVersion = adapter.WiFiVersion;
        _hasEmbeddedBluetoothModule = adapter.HasEmbeddedBluetoothModule;
        _pciEVersion = adapter.PciEVersion;
        _powerConsumption = adapter.PowerConsumption;

        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wiFiVersion,
            _hasEmbeddedBluetoothModule,
            _pciEVersion,
            _powerConsumption);
    }
}
