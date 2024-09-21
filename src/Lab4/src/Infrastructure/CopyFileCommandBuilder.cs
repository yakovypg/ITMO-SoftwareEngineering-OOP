using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class CopyFileCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationDirectoryPath;
    private FileSystem? _fileSystem;

    public CopyFileCommandBuilder AddSourcePath(string path)
    {
        _sourcePath = path ?? throw new ArgumentNullException(nameof(path));
        return this;
    }

    public CopyFileCommandBuilder AddDestinationDirectoryPath(string path)
    {
        _destinationDirectoryPath = path ?? throw new ArgumentNullException(nameof(path));
        return this;
    }

    public CopyFileCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public CopyFileCommand Build()
    {
        if (_sourcePath is null)
            throw new MissingParameterException(nameof(_sourcePath), null, null);

        if (_destinationDirectoryPath is null)
            throw new MissingParameterException(nameof(_destinationDirectoryPath), null, null);

        return new CopyFileCommand(_sourcePath, _destinationDirectoryPath, _fileSystem);
    }
}
