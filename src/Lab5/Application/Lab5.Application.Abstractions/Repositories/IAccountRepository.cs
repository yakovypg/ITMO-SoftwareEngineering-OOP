using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account? FindAccount(string username);
    void AddAccount(string username);
}
