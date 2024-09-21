using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;

public class CurrentAccountService : ICurrentAccountService
{
    public Account? CurrentAccount { get; set; }
}
