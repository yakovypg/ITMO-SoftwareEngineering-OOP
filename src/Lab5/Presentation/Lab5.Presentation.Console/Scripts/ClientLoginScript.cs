using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ClientLoginScript : Script
{
    private readonly IUserService _userService;

    public ClientLoginScript(IUserService userService, IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public override string Description => "Log in as user";

    public override void Execute()
    {
        string username = Console.Ask<string>("Enter username:");
        string password = Console.Ask<string>("Enter PIN:");

        LoginResult loginResult = _userService.Login(username, password);

        string message = loginResult switch
        {
            LoginResult.UserNotFound => "User not found",
            LoginResult.IncorrectPassword => "PIN is incorrect",
            LoginResult.Success => "Successful login",

            _ => throw new ArgumentOutOfRangeException(nameof(loginResult)),
        };

        Console.WriteLine(message);
    }
}
