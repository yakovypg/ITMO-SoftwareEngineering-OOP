using System;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowFileCommand : Command
{
    private readonly ITextWriter _textWriter;

    public ShowFileCommand(string path, OutputMode mode, FileSystem? fileSystem = null)
        : base(fileSystem)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));

        _textWriter = mode switch
        {
            OutputMode.Console => new ConsoleOutputWriter(),
            _ => throw new NotSupportedException(),
        };

        Mode = mode;
    }

    public string Path { get; }
    public OutputMode Mode { get; }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        if (!FileSystem.IsConnected)
            throw new FileSystemNotConnectedException();

        if (FileSystem.FileInteractionProvider is null)
            throw new FileSystemNotConnectedCorrectlyException();

        string absolutePath = FileSystem.GetAbsolutePath(Path);
        string text = FileSystem.FileInteractionProvider.ReadText(absolutePath);

        _textWriter.WriteLine(text);
    }
}
