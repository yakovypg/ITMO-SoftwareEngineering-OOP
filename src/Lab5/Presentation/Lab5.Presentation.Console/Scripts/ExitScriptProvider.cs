using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ExitScriptProvider : IScriptProvider
{
    public bool TryGetScript([NotNullWhen(true)] out IScript? script)
    {
        script = new ExitScript();
        return true;
    }
}
