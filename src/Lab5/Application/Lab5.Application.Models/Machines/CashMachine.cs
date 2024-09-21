namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;

public class CashMachine
{
    public CashMachine(int serialNumber)
    {
        SerialNumber = serialNumber;
    }

    public int SerialNumber { get; }
}
