using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class AdminLoginScriptProvider : IScriptProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public AdminLoginScriptProvider(IUserService userService, ICurrentUserService currentUserService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
    }

    public bool TryGetScript([NotNullWhen(true)] out IScript? script)
    {
        if (_currentUserService.CurrentUser is not null)
        {
            script = null;
            return false;
        }

        script = new AdminLoginScript(_userService);
        return true;
    }
}
