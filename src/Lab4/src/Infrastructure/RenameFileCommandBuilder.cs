using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class RenameFileCommandBuilder
{
    private string? _path;
    private string? _newName;
    private FileSystem? _fileSystem;

    public RenameFileCommandBuilder AddPath(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        return this;
    }

    public RenameFileCommandBuilder AddNewName(string newName)
    {
        _newName = newName ?? throw new ArgumentNullException(nameof(newName));
        return this;
    }

    public RenameFileCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public RenameFileCommand Build()
    {
        if (_path is null)
            throw new MissingParameterException(nameof(_path), null, null);

        if (_newName is null)
            throw new MissingParameterException(nameof(_newName), null, null);

        return new RenameFileCommand(_path, _newName, _fileSystem);
    }
}
