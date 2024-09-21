using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CustomDisplayDriverMock : CustomDisplayDriver
{
    public CustomDisplayDriverMock(IColoredTextWriter? textWriter = null)
        : base(textWriter ?? new ConsoleTextWriterMock())
    {
    }

    public int ClearCallsNumber { get; private set; }
    public int WriteCallsNumber { get; private set; }

    public override void Clear()
    {
        base.Clear();
        ClearCallsNumber++;
    }

    public override void WriteLine(string? text)
    {
        base.WriteLine(text);
        WriteCallsNumber++;
    }
}
