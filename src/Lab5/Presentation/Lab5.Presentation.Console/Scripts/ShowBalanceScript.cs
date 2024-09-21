using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ShowBalanceScript : Script
{
    private readonly ICurrentAccountService _currentAccountService;

    public ShowBalanceScript(ICurrentAccountService currentAccountService, IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _currentAccountService = currentAccountService
            ?? throw new ArgumentNullException(nameof(currentAccountService));
    }

    public override string Description => "Show balance";

    public override void Execute()
    {
        double money = _currentAccountService.CurrentAccount?.Money ?? 0;
        Console.WriteLine($"Current balance: {money}");
    }
}
