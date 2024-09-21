using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class DiscordMessengerToIMessengerAdapter : IMessenger
{
    private readonly IDiscordMessenger _messenger;

    public DiscordMessengerToIMessengerAdapter(IDiscordMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _messenger.Send(message.ToString());
    }
}
