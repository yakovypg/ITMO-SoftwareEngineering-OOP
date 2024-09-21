using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
public class MissingComponentException : Exception
{
    private const string DefaultMessage = "Computer does not contain a required component";

    public MissingComponentException()
        : this(DefaultMessage, null)
    {
    }

    public MissingComponentException(string? message)
        : this(message, null)
    {
    }

    public MissingComponentException(string? message, Exception? innerException)
        : this(null, message, innerException)
    {
    }

    public MissingComponentException(Type? componentType, string? message = null, Exception? innerException = null)
        : base(message ?? DefaultMessage, innerException)
    {
        ComponentType = componentType;
    }

    public Type? ComponentType { get; }
}
