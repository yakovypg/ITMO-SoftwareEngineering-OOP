using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

public interface IConsole
{
    T MakeChoice<T>(IEnumerable<T> choices, string title, Func<T, string> converter)
        where T : notnull;

    T Ask<T>(string prompt);

    void Write(object value);
    void Write(string value);
    void WriteLine(string value);
}
