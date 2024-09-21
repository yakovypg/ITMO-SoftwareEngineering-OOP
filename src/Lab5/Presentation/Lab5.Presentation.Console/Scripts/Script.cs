using System;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public abstract class Script : IScript
{
    protected Script(IConsole console)
    {
        Console = console ?? throw new ArgumentNullException(nameof(console));
    }

    public abstract string Description { get; }
    protected IConsole Console { get; }

    public abstract void Execute();
}
