namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Interactions;

public interface IAccountMoneyInteraction
{
    void DepositMoney(string username, double money);
    void WithdrawMoney(string username, double money);
}
