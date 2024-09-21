using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class User : EndpointUnit
{
    private readonly Dictionary<Message, bool> _messages; // Message -> IsReaded

    public User()
    {
        _messages = new();
    }

    public IReadOnlyDictionary<Message, bool> Messages => _messages;

    public override void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _ = _messages.TryAdd(message, false);
    }

    public void MarkMessageAsReaded(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        if (!_messages.ContainsKey(message))
            throw new UserNotRecieveMessageException(message);

        if (_messages[message])
            throw new MessageReadedException(message);

        _messages[message] = true;
    }

    public override void Add(EndpointUnit unit)
    {
    }

    public override void Remove(EndpointUnit unit)
    {
    }
}
