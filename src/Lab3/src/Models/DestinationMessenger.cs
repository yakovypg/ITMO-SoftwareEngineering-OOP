using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class DestinationMessenger : IDestination
{
    private readonly IMessenger _messenger;

    public DestinationMessenger(IMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));
        _messenger.SendMessage(message);
    }
}
