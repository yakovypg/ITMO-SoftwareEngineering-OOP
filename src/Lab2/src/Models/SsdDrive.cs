using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class SsdDrive
{
    public SsdDrive(
        double sizeGb,
        int maxSpeed,
        double powerConsumption,
        PciEVersion? pciEVersion = null)
    {
        ConnectionType = pciEVersion is null
            ? SsdDriveConnectionType.Sata
            : SsdDriveConnectionType.PCIe;

        PciEVersion = pciEVersion;
        SizeGb = sizeGb;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public PciEVersion? PciEVersion { get; }
    public SsdDriveConnectionType ConnectionType { get; }
    public double SizeGb { get; }
    public int MaxSpeed { get; }
    public double PowerConsumption { get; }
}
