using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class AdminLoginScript : Script
{
    private readonly IUserService _userService;

    public AdminLoginScript(IUserService userService, IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public override string Description => "Log in as admin";

    public override void Execute()
    {
        string password = Console.Ask<string>("Enter password:");

        LoginResult loginResult = _userService.Login("admin", password);

        string message = loginResult switch
        {
            LoginResult.UserNotFound => "Admin not found",
            LoginResult.IncorrectPassword => "Password is incorrect",
            LoginResult.Success => "Successful login",

            _ => throw new ArgumentOutOfRangeException(nameof(loginResult)),
        };

        Console.WriteLine(message);

        if (loginResult == LoginResult.IncorrectPassword)
            Environment.Exit(0);
    }
}
