using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class SelectCashMachineScriptProvider : IScriptProvider
{
    private readonly ICashMachineService _cashMachineService;
    private readonly ICurrentCashMachineService _currentCashMachineService;
    private readonly ICurrentUserService _currentUserService;

    public SelectCashMachineScriptProvider(
        ICashMachineService cashMachineService,
        ICurrentCashMachineService currentCashMachineService,
        ICurrentUserService currentUserService)
    {
        _cashMachineService = cashMachineService
            ?? throw new ArgumentNullException(nameof(cashMachineService));

        _currentCashMachineService = currentCashMachineService
            ?? throw new ArgumentNullException(nameof(currentCashMachineService));

        _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));
    }

    public bool TryGetScript([NotNullWhen(true)] out IScript? script)
    {
        if (_currentUserService.CurrentUser is null
            || _currentUserService.CurrentUser.Role == UserRole.Admin)
        {
            script = null;
            return false;
        }

        script = new SelectCashMachineScript(_cashMachineService, _currentCashMachineService);
        return true;
    }
}
