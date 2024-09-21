using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class IncompatibleComponentException : Exception
{
    private const string DefaultMessage = "Computer contains an incompatible component";

    public IncompatibleComponentException()
        : this(DefaultMessage, null)
    {
    }

    public IncompatibleComponentException(string? message)
        : this(message, null)
    {
    }

    public IncompatibleComponentException(string? message, Exception? innerException)
        : this(null, message, innerException)
    {
    }

    public IncompatibleComponentException(Type? componentType, string? message = null, Exception? innerException = null)
        : base(message ?? DefaultMessage, innerException)
    {
        ComponentType = componentType;
    }

    public Type? ComponentType { get; }
}
