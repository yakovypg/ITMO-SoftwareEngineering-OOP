using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileSystemNotConnectedException : Exception
{
    public FileSystemNotConnectedException()
        : this(null)
    {
    }

    public FileSystemNotConnectedException(string? message)
        : this(message, null)
    {
    }

    public FileSystemNotConnectedException(string? message, Exception? innerException)
        : base(message ?? "File system not connected", innerException)
    {
    }
}
