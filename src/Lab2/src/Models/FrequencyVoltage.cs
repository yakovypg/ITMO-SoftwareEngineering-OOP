namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class FrequencyVoltage
{
    public FrequencyVoltage(double frequency, double voltage)
    {
        Frequency = frequency;
        Voltage = voltage;
    }

    public double Frequency { get; }
    public double Voltage { get; }
}
