using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileExistsException : Exception
{
    public FileExistsException()
        : this(null)
    {
    }

    public FileExistsException(string? message)
        : this(message, null)
    {
    }

    public FileExistsException(string? message, Exception? innerException)
        : this(string.Empty, message, innerException)
    {
    }

    public FileExistsException(string path, string? message = null, Exception? innerException = null)
        : base(message ?? "File with the specified name already exists", innerException)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public string Path { get; }
}
