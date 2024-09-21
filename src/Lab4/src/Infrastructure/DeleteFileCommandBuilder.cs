using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class DeleteFileCommandBuilder
{
    private string? _path;
    private FileSystem? _fileSystem;

    public DeleteFileCommandBuilder AddPath(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        return this;
    }

    public DeleteFileCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public DeleteFileCommand Build()
    {
        if (_path is null)
            throw new MissingParameterException(nameof(_path), null, null);

        return new DeleteFileCommand(_path, _fileSystem);
    }
}
