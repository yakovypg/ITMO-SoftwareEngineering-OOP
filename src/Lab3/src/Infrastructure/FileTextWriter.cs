using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

public class FileTextWriter : ITextWriter
{
    public FileTextWriter(string filePath)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public string FilePath { get; }

    public virtual void Clear()
    {
        File.Create(FilePath).Close();
    }

    public virtual void Write(string? message)
    {
        File.AppendAllText(FilePath, message);
    }

    public virtual void WriteLine(string? message)
    {
        File.AppendAllText(FilePath, message + Environment.NewLine);
    }
}
