using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ShowOperationHistoryScriptProvider : IScriptProvider
{
    private readonly ICurrentAccountService _currentAccountService;
    private readonly IOperationService _operationService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentCashMachineService _currentCashMachineService;

    public ShowOperationHistoryScriptProvider(
        ICurrentAccountService currentAccountService,
        IOperationService operationService,
        ICurrentUserService currentUserService,
        ICurrentCashMachineService currentCashMachineService)
    {
        _currentAccountService = currentAccountService
            ?? throw new ArgumentNullException(nameof(currentAccountService));

        _operationService = operationService
            ?? throw new ArgumentNullException(nameof(operationService));

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

        script = new ShowOperationHistoryScript(_operationService, _currentUserService);
        return true;
    }
}
