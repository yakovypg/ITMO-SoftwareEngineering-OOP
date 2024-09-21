namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class HardDisk
{
    public HardDisk(double sizeGb, int speed, double powerConsumption)
    {
        SizeGb = sizeGb;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    public double SizeGb { get; }
    public int Speed { get; }
    public double PowerConsumption { get; }
}
