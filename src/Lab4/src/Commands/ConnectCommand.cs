using System;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : Command
{
    public ConnectCommand(string address, FileSystemMode mode, FileSystem? fileSystem = null)
        : base(fileSystem)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Mode = mode;
    }

    public string Address { get; }
    public FileSystemMode Mode { get; }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        FileSystem.Connect(Address, Mode);
    }
}
