using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.IO;

public class ConsoleOutputWriter : OutputWriter
{
    public ConsoleOutputWriter()
        : base(Console.Out)
    {
    }
}
