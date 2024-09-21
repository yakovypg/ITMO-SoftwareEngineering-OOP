using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComponentNotRegisteredException : Exception
{
    private const string DefaultMessage = "Component is not registered in the repository";

    public ComponentNotRegisteredException()
        : this(DefaultMessage, null)
    {
    }

    public ComponentNotRegisteredException(string? message)
        : this(message, null)
    {
    }

    public ComponentNotRegisteredException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
