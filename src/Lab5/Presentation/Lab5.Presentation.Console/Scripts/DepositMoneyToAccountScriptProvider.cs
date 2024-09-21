using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class DepositMoneyToAccountScriptProvider : IScriptProvider
{
    private readonly ICurrentAccountService _currentAccountService;
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentCashMachineService _currentCashMachineService;

    public DepositMoneyToAccountScriptProvider(
        ICurrentAccountService currentAccountService,
        IAccountService accountService,
        ICurrentUserService currentUserService,
        ICurrentCashMachineService currentCashMachineService)
    {
        _currentAccountService = currentAccountService
            ?? throw new ArgumentNullException(nameof(currentAccountService));

        _accountService = accountService
            ?? throw new ArgumentNullException(nameof(accountService));

        _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));

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

        script = new DepositMoneyToAccountScript(
            _accountService,
            _currentUserService,
            _currentCashMachineService);

        return true;
    }
}
