namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PowerSupply
{
    public PowerSupply(double peakLoad, double recommendedMaxLoad)
    {
        PeakLoad = peakLoad;
        RecommendedMaxLoad = recommendedMaxLoad;
    }

    public double PeakLoad { get; }
    public double RecommendedMaxLoad { get; }
}
