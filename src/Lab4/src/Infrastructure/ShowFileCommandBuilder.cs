using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class ShowFileCommandBuilder
{
    private string? _path;
    private OutputMode _mode;
    private FileSystem? _fileSystem;

    public ShowFileCommandBuilder AddPath(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        return this;
    }

    public ShowFileCommandBuilder AddMode(OutputMode mode)
    {
        _mode = mode;
        return this;
    }

    public ShowFileCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public ShowFileCommand Build()
    {
        if (_path is null)
            throw new MissingParameterException(nameof(_path), null, null);

        return new ShowFileCommand(_path, _mode, _fileSystem);
    }
}
