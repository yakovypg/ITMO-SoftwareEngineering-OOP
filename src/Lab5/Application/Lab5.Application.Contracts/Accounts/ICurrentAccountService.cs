using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;

public interface ICurrentAccountService
{
    Account? CurrentAccount { get; set; }
}
