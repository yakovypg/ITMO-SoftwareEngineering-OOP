using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public abstract class DisplayDriverDecorator : DisplayDriver
{
    protected DisplayDriverDecorator(DisplayDriver driver, IColoredTextWriter displayOut)
        : base(displayOut)
    {
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
    }

    protected DisplayDriver Driver { get; }
}
