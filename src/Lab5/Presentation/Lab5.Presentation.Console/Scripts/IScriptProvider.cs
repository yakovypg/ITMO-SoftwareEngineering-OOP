using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public interface IScriptProvider
{
    bool TryGetScript([NotNullWhen(true)] out IScript? script);
}
