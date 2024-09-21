using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class WiFiAdapter
{
    public WiFiAdapter(
        int wiFiVersion,
        bool hasEmbeddedBluetoothModule,
        PciEVersion pciEVersion,
        double powerConsumption)
    {
        WiFiVersion = wiFiVersion;
        HasEmbeddedBluetoothModule = hasEmbeddedBluetoothModule;
        PciEVersion = pciEVersion;
        PowerConsumption = powerConsumption;
    }

    public int WiFiVersion { get; }
    public bool HasEmbeddedBluetoothModule { get; }
    public PciEVersion PciEVersion { get; }
    public double PowerConsumption { get; }
}
