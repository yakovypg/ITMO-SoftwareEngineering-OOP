using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class UnknownCommandException : Exception
{
    public UnknownCommandException()
        : this(null)
    {
    }

    public UnknownCommandException(string? message)
        : this(message, null)
    {
    }

    public UnknownCommandException(string? message, Exception? innerException)
        : this(string.Empty, message, innerException)
    {
    }

    public UnknownCommandException(string commandName, string? message = null, Exception? innerException = null)
        : base(message ?? $"Command {commandName} is unknown", innerException)
    {
        CommandName = commandName ?? throw new ArgumentNullException(nameof(commandName));
    }

    public string CommandName { get; }
}
