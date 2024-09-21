namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;

public class Account
{
    public Account(double money)
    {
        Money = money;
    }

    public double Money { get; }
}
