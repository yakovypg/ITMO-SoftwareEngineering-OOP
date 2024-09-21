using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public abstract class DisplayDriver
{
    private ConsoleColor _foregroundColor;

    protected DisplayDriver(IColoredTextWriter displayOut)
    {
        Out = displayOut ?? throw new ArgumentNullException(nameof(displayOut));
    }

    public virtual ConsoleColor ForegroundColor
    {
        get => _foregroundColor;
        set
        {
            _foregroundColor = value;
            Out.ForegroundColor = value;
        }
    }

    protected IColoredTextWriter Out { get; }

    public virtual void Clear()
    {
        Out.Clear();
    }

    public virtual void WriteLine(string? text)
    {
        Out.WriteLine(text);
    }
}
