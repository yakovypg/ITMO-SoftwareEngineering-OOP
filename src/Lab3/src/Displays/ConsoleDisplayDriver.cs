using Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class ConsoleDisplayDriver : DisplayDriver
{
    public ConsoleDisplayDriver()
        : base(new ConsoleTextWriter())
    {
    }
}
