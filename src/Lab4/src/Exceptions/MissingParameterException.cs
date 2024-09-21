using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class MissingParameterException : Exception
{
    public MissingParameterException()
        : this(null)
    {
    }

    public MissingParameterException(string? message)
        : this(message, null)
    {
    }

    public MissingParameterException(string? message, Exception? innerException)
        : this(string.Empty, message, innerException)
    {
    }

    public MissingParameterException(string parameter, string? message = null, Exception? innerException = null)
        : base(message ?? $"Parameter {parameter} missed", innerException)
    {
        Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
    }

    public string Parameter { get; }
}
