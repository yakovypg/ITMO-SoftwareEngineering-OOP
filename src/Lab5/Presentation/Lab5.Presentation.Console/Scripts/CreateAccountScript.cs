using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class CreateAccountScript : Script
{
    private readonly IUserService _userService;

    public CreateAccountScript(IUserService userService, IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public override string Description => "Create account";

    public override void Execute()
    {
        string username = Console.Ask<string>("Enter username:");
        string password = Console.Ask<string>("Enter PIN:");

        RegisterResult registerResult = _userService.Register(username, password);

        string message = registerResult switch
        {
            RegisterResult.UsernameAlreadyExists => "Username already exists",
            RegisterResult.Success => "Successful registration",

            _ => throw new ArgumentOutOfRangeException(nameof(registerResult)),
        };

        Console.WriteLine(message);
    }
}
