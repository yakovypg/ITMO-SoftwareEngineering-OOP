using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class OutputWriter : ITextWriter
{
    public OutputWriter(TextWriter output)
    {
        Out = output ?? throw new ArgumentNullException(nameof(output));
    }

    protected TextWriter Out { get; }

    public virtual void Write(string? text)
    {
        Out.Write(text);
    }

    public virtual void WriteLine(string? text)
    {
        Out.WriteLine(text);
    }
}
