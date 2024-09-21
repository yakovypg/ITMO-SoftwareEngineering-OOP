using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;
public class ConsoleTextWriterMock : ConsoleTextWriter
{
    private readonly StringBuilder _output;

    public ConsoleTextWriterMock()
    {
        _output = new StringBuilder();
    }

    public int ClearCallsNumber { get; private set; }
    public int WriteCallsNumber { get; private set; }
    public int WriteLineCallsNumber { get; private set; }

    public string Output => _output.ToString();

    public override void Clear()
    {
        _output.Clear();
        ClearCallsNumber++;
    }

    public override void Write(string? message)
    {
        _output.Append(message);
        WriteCallsNumber++;
    }

    public override void WriteLine(string? message)
    {
        _output.AppendLine(message);
        WriteLineCallsNumber++;
    }
}
