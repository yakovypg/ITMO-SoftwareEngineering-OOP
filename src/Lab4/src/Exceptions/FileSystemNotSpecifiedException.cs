using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileSystemNotSpecifiedException : Exception
{
    public FileSystemNotSpecifiedException()
        : this(null)
    {
    }

    public FileSystemNotSpecifiedException(string? message)
        : this(message, null)
    {
    }

    public FileSystemNotSpecifiedException(string? message, Exception? innerException)
        : base(message ?? "File system not specified", innerException)
    {
    }
}
