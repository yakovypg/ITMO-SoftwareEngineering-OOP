using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ScriptExecutor
{
    private readonly IEnumerable<IScriptProvider> _scriptProviders;

    public ScriptExecutor(IEnumerable<IScriptProvider> scriptProviders)
    {
        _scriptProviders = scriptProviders;
    }

    public void Execute()
    {
        IEnumerable<IScript> scripts = GetScripts();

        SelectionPrompt<IScript> selectionPrompt = new SelectionPrompt<IScript>()
            .Title("Select action:")
            .AddChoices(scripts)
            .UseConverter(t => t.Description);

        IScript script = AnsiConsole.Prompt(selectionPrompt);
        script.Execute();
    }

    public bool TryExecute()
    {
#pragma warning disable CA1031 // Do not catch general exception types
        try
        {
            Execute();
            return true;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteLine(ex.Message);
            return false;
        }
#pragma warning restore CA1031 // Do not catch general exception types
    }

    private IEnumerable<IScript> GetScripts()
    {
        foreach (IScriptProvider scriptProvider in _scriptProviders)
        {
            if (scriptProvider.TryGetScript(out IScript? script))
                yield return script;
        }
    }
}
