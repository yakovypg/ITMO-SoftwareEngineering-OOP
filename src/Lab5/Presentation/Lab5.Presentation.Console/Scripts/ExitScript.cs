using System;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ExitScript : IScript
{
    public string Description => "Exit";

    public void Execute()
    {
        Environment.Exit(0);
    }
}
