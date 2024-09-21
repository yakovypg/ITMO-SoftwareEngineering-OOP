using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class MoveFileCommand : Command
{
    public MoveFileCommand(string sourcePath, string destinationDirectoryPath, FileSystem? fileSystem = null)
        : base(fileSystem)
    {
        SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));

        DestinationDirectoryPath = destinationDirectoryPath
            ?? throw new ArgumentNullException(nameof(destinationDirectoryPath));
    }

    public string SourcePath { get; }
    public string DestinationDirectoryPath { get; }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        if (!FileSystem.IsConnected)
            throw new FileSystemNotConnectedException();

        if (FileSystem.FileInteractionProvider is null)
            throw new FileSystemNotConnectedCorrectlyException();

        string absoluteSourcePath = FileSystem.GetAbsolutePath(SourcePath);
        string absoluteDestinationDirectoryPath = FileSystem.GetAbsolutePath(DestinationDirectoryPath);

        string? fileName = Path.GetFileName(SourcePath);
        string absoluteDestinationPath = Path.Combine(absoluteDestinationDirectoryPath, fileName);

        if (absoluteSourcePath == absoluteDestinationPath)
            throw new FileExistsException("Destination directory has a file with the same name");

        FileSystem.FileInteractionProvider.Move(absoluteSourcePath, absoluteDestinationPath);
    }
}
