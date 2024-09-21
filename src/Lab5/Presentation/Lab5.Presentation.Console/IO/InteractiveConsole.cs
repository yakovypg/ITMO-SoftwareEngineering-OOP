using System;
using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

public class InteractiveConsole : IConsole
{
    public T MakeChoice<T>(IEnumerable<T> choices, string title, Func<T, string> converter)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(choices, nameof(choices));
        ArgumentNullException.ThrowIfNull(title, nameof(title));
        ArgumentNullException.ThrowIfNull(converter, nameof(converter));

        SelectionPrompt<T> selectionPrompt = new SelectionPrompt<T>()
            .Title(title)
            .AddChoices(choices)
            .UseConverter(converter);

        return AnsiConsole.Prompt(selectionPrompt);
    }

    public T Ask<T>(string prompt)
    {
        ArgumentNullException.ThrowIfNull(prompt, nameof(prompt));
        return AnsiConsole.Ask<T>(prompt);
    }

    public void Write(object value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value is IRenderable renderable)
            AnsiConsole.Write(renderable);
        else
            Write(value.ToString() ?? string.Empty);
    }

    public void Write(string value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        AnsiConsole.Write(value);
    }

    public void WriteLine(string value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        AnsiConsole.WriteLine(value);
    }
}
