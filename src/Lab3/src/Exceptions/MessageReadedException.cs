using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageReadedException : Exception
{
    public MessageReadedException()
        : this(null)
    {
    }

    public MessageReadedException(string? message)
        : this(message, null)
    {
    }

    public MessageReadedException(string? message, Exception? innerException)
        : this(null, message, innerException)
    {
    }

    public MessageReadedException(Message? recievedMessage, string? message = null, Exception? innerException = null)
        : base(message, innerException)
    {
        RecievedMessage = recievedMessage ?? throw new ArgumentNullException(nameof(recievedMessage));
    }

    public Message? RecievedMessage { get; }
}
