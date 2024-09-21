using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

public class ConsoleTextWriter : IColoredTextWriter
{
    public ConsoleTextWriter(ConsoleColor foregroundColor = ConsoleColor.White)
    {
        ForegroundColor = foregroundColor;
    }

    public ConsoleColor ForegroundColor { get; set; }

    public virtual void Clear()
    {
        Console.Clear();
    }

    public virtual void Write(string? message)
    {
        PerformWithSettingForegroundColor(() => Console.Write(message));
    }

    public virtual void WriteLine(string? message)
    {
        PerformWithSettingForegroundColor(() => Console.WriteLine(message));
    }

    private void PerformWithSettingForegroundColor(Action action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));

        ConsoleColor tempColor = Console.ForegroundColor;

        Console.ForegroundColor = ForegroundColor;
        action.Invoke();
        Console.ForegroundColor = tempColor;
    }
}
