using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class GotoCommand : Command
{
    public GotoCommand(string path, FileSystem? fileSystem = null)
        : base(fileSystem)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public string Path { get; }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        if (!FileSystem.IsConnected)
            throw new FileSystemNotConnectedException();

        FileSystem.Move(Path);
    }
}
