using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class IncorrectCommandDataException : Exception
{
    public IncorrectCommandDataException()
        : this(null)
    {
    }

    public IncorrectCommandDataException(string? message)
        : this(message, null)
    {
    }

    public IncorrectCommandDataException(string? message, Exception? innerException)
        : this(null, message, innerException)
    {
    }

    public IncorrectCommandDataException(CommandData? data, string? message = null, Exception? innerException = null)
        : base(message ?? "Command data is incorrect", innerException)
    {
        CommandData = data;
    }

    public CommandData? CommandData { get; }
}
