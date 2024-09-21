using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class RenameFileCommand : Command
{
    public RenameFileCommand(string path, string newName, FileSystem? fileSystem = null)
        : base(fileSystem)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        NewName = newName ?? throw new ArgumentNullException(nameof(newName));
    }

    public string Path { get; }
    public string NewName { get; }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        if (!FileSystem.IsConnected)
            throw new FileSystemNotConnectedException();

        if (FileSystem.FileInteractionProvider is null)
            throw new FileSystemNotConnectedCorrectlyException();

        string absolutePath = FileSystem.GetAbsolutePath(Path);
        string renamedFilePath = FileSystem.FileInteractionProvider.ChangeFileNameInPath(absolutePath, NewName);

        if (absolutePath == renamedFilePath)
            throw new FileExistsException();

        FileSystem.FileInteractionProvider.Rename(absolutePath, NewName);
    }
}
