namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    void DepositMoneyToAccount(string username, double money, int cashMachineSerialNumber);
    void WithdrawMoneyFromAccount(string username, double money, int cashMachineSerialNumber);
}
