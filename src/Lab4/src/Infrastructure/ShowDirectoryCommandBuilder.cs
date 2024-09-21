using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class ShowDirectoryCommandBuilder
{
    private int _depth = -1;
    private OutputMode _mode;
    private PrintDecorations? _printDecorations;
    private FileSystem? _fileSystem;

    public ShowDirectoryCommandBuilder AddDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ShowDirectoryCommandBuilder AddOutputMode(OutputMode mode)
    {
        _mode = mode;
        return this;
    }

    public ShowDirectoryCommandBuilder AddPrintDecorations(PrintDecorations printDecorations)
    {
        _printDecorations = printDecorations ?? throw new ArgumentNullException(nameof(printDecorations));
        return this;
    }

    public ShowDirectoryCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public ShowDirectoryCommand Build()
    {
        if (_printDecorations is null)
            throw new MissingParameterException(nameof(_printDecorations), null, null);

        return new ShowDirectoryCommand(_mode, _printDecorations, _depth, _fileSystem);
    }
}
