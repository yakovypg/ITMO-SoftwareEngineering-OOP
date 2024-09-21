using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Gpu
{
    public Gpu(
        double height,
        double width,
        double memoryGb,
        PciEVersion pciEVersion,
        double chipFrequency,
        double powerConsumption)
    {
        Height = height;
        Width = width;
        MemoryGb = memoryGb;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public double Height { get; }
    public double Width { get; }
    public double MemoryGb { get; }
    public PciEVersion PciEVersion { get; }
    public double ChipFrequency { get; }
    public double PowerConsumption { get; }
}
