using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ShowBalanceScriptProvider : IScriptProvider
{
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICurrentCashMachineService _currentCashMachineService;

    public ShowBalanceScriptProvider(
        ICurrentAccountService currentAccountService,
        ICurrentCashMachineService currentCashMachineService)
    {
        _currentAccountService = currentAccountService
            ?? throw new ArgumentNullException(nameof(currentAccountService));

        _currentCashMachineService = currentCashMachineService
            ?? throw new ArgumentNullException(nameof(currentCashMachineService));
    }

    public bool TryGetScript([NotNullWhen(true)] out IScript? script)
    {
        if (_currentAccountService.CurrentAccount is null
            || _currentCashMachineService.CurrentCashMachine is null)
        {
            script = null;
            return false;
        }

        script = new ShowBalanceScript(_currentAccountService);
        return true;
    }
}
