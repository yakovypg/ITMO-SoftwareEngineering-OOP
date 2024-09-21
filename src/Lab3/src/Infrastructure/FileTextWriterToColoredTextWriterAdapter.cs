using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;

public class FileTextWriterToColoredTextWriterAdapter : IColoredTextWriter
{
    private readonly FileTextWriter _fileTextWriter;

    public FileTextWriterToColoredTextWriterAdapter(FileTextWriter fileTextWriter)
    {
        _fileTextWriter = fileTextWriter ?? throw new ArgumentNullException(nameof(fileTextWriter));
    }

    public ConsoleColor ForegroundColor { get; set; }

    public void Clear()
    {
        _fileTextWriter.Clear();
    }

    public void Write(string? message)
    {
        _fileTextWriter.Write(message);
    }

    public void WriteLine(string? message)
    {
        _fileTextWriter.WriteLine(message);
    }
}
