using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class TelegramMessengerToIMessengerAdapter : IMessenger
{
    private readonly ITelegramMessenger _messenger;

    public TelegramMessengerToIMessengerAdapter(ITelegramMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _messenger.Send(message.Body, message.Header);
    }
}
