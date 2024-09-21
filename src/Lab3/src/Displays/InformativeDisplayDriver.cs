using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class InformativeDisplayDriver : DisplayDriverDecorator
{
    public InformativeDisplayDriver(DisplayDriver driver, IColoredTextWriter displayOut)
        : base(
            driver ?? throw new ArgumentNullException(nameof(driver)),
            displayOut ?? throw new ArgumentNullException(nameof(displayOut)))
    {
    }

    public override void Clear()
    {
        Driver.Clear();
    }

    public override void WriteLine(string? text)
    {
        string? colorName = Enum.GetName(typeof(ConsoleColor), Out.ForegroundColor);
        Driver.WriteLine($"[{colorName}] {text}");
    }
}
