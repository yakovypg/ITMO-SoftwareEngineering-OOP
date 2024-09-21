using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class DisconnectCommandBuilder
{
    private FileSystem? _fileSystem;

    public DisconnectCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public DisconnectCommand Build()
    {
        return new DisconnectCommand(_fileSystem);
    }
}
