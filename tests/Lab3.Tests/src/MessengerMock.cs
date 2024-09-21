using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerMock : SimpleMessenger
{
    public MessengerMock(ITextWriter? textWriter = null, ImportanceFilter? filter = null, ITextWriter? logger = null)
        : base(textWriter ?? new ConsoleTextWriterMock(), filter, logger)
    {
    }

    public int ReceivedMessages { get; private set; }

    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        ReceivedMessages++;
    }
}
