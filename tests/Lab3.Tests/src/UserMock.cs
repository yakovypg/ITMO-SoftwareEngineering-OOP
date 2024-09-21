using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UserMock : User
{
    public int ReceivedMessages { get; private set; }

    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        ReceivedMessages++;
    }
}
