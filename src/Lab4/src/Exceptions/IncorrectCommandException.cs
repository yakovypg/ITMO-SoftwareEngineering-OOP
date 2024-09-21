using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class IncorrectCommandException : Exception
{
    public IncorrectCommandException()
        : this(null)
    {
    }

    public IncorrectCommandException(string? message)
        : this(message, null)
    {
    }

    public IncorrectCommandException(string? message, Exception? innerException)
        : this(string.Empty, message, innerException)
    {
    }

    public IncorrectCommandException(string command, string? message = null, Exception? innerException = null)
        : base(message ?? "Command is incorrect", innerException)
    {
        Command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public string Command { get; }
}
