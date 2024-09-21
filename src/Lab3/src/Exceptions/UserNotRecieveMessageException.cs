using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class UserNotRecieveMessageException : Exception
{
    public UserNotRecieveMessageException()
        : this(null)
    {
    }

    public UserNotRecieveMessageException(string? message)
        : this(message, null)
    {
    }

    public UserNotRecieveMessageException(string? message, Exception? innerException)
        : this(null, message, innerException)
    {
    }

    public UserNotRecieveMessageException(Message? recievedMessage, string? message = null, Exception? innerException = null)
        : base(message, innerException)
    {
        RecievedMessage = recievedMessage ?? throw new ArgumentNullException(nameof(recievedMessage));
    }

    public Message? RecievedMessage { get; }
}
