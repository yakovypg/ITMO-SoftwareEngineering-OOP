using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileSystemNotConnectedCorrectlyException : Exception
{
    public FileSystemNotConnectedCorrectlyException()
        : this(null)
    {
    }

    public FileSystemNotConnectedCorrectlyException(string? message)
        : this(message, null)
    {
    }

    public FileSystemNotConnectedCorrectlyException(string? message, Exception? innerException)
        : base(message ?? "File system not connected correctly", innerException)
    {
    }
}
