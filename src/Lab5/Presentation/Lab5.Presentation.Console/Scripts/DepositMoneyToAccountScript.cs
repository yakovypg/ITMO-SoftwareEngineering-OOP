using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class DepositMoneyToAccountScript : Script
{
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentCashMachineService _currentCashMachineService;

    public DepositMoneyToAccountScript(
        IAccountService accountService,
        ICurrentUserService currentUserService,
        ICurrentCashMachineService currentCashMachineService,
        IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _accountService = accountService
            ?? throw new ArgumentNullException(nameof(accountService));

        _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));

        _currentCashMachineService = currentCashMachineService
            ?? throw new ArgumentNullException(nameof(currentCashMachineService));
    }

    public override string Description => "Deposit money";

    public override void Execute()
    {
        ArgumentNullException.ThrowIfNull(
            _currentUserService.CurrentUser,
            nameof(_currentUserService.CurrentUser));

        ArgumentNullException.ThrowIfNull(
            _currentCashMachineService.CurrentCashMachine,
            nameof(_currentCashMachineService.CurrentCashMachine));

        double depositAmount = Console.Ask<double>("Enter deposit amount:");

        _accountService.DepositMoneyToAccount(
            _currentUserService.CurrentUser.Username,
            depositAmount,
            _currentCashMachineService.CurrentCashMachine.SerialNumber);

        Console.WriteLine($"Added {depositAmount} rubles");
    }
}
