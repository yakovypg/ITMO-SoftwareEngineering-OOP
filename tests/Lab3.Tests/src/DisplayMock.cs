using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class DisplayMock : ConsoleDisplay
{
    public DisplayMock(ImportanceFilter? filter = null, ITextWriter? logger = null)
        : base(new CustomDisplayDriver(new ConsoleTextWriterMock()), filter, logger)
    {
    }

    public int ReceivedMessages { get; private set; }

    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        ReceivedMessages++;
    }
}
