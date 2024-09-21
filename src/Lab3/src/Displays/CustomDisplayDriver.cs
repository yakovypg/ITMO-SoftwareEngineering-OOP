using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class CustomDisplayDriver : DisplayDriver
{
    public CustomDisplayDriver(IColoredTextWriter displayOut)
        : base(displayOut ?? throw new ArgumentNullException(nameof(displayOut)))
    {
    }
}
