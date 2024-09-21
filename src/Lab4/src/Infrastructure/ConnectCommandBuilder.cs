using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class ConnectCommandBuilder
{
    private string? _address;
    private FileSystemMode _mode;
    private FileSystem? _fileSystem;

    public ConnectCommandBuilder AddAddress(string address)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address));
        return this;
    }

    public ConnectCommandBuilder AddMode(FileSystemMode mode)
    {
        _mode = mode;
        return this;
    }

    public ConnectCommandBuilder AddFileSystem(FileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        return this;
    }

    public ConnectCommand Build()
    {
        if (_address is null)
            throw new MissingParameterException(nameof(_address), null, null);

        return new ConnectCommand(_address, _mode, _fileSystem);
    }
}
