using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DeleteFileCommand : Command
{
    public DeleteFileCommand(string path, FileSystem? fileSystem = null)
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

        if (FileSystem.FileInteractionProvider is null)
            throw new FileSystemNotConnectedCorrectlyException();

        string absolutePath = FileSystem.GetAbsolutePath(Path);
        FileSystem.FileInteractionProvider.Delete(absolutePath);
    }
}
