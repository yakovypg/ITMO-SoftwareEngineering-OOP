using System;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowDirectoryCommand : Command
{
    private readonly ITextWriter _textWriter;

    public ShowDirectoryCommand(
        OutputMode mode,
        PrintDecorations printDecorations,
        int depth,
        FileSystem? fileSystem = null)
        : base(fileSystem)
    {
        PrintDecorations = printDecorations ?? throw new ArgumentNullException(nameof(printDecorations));

        _textWriter = mode switch
        {
            OutputMode.Console => new ConsoleOutputWriter(),
            _ => throw new NotSupportedException(),
        };

        Mode = mode;
        Depth = depth;
    }

    public int Depth { get; }
    public OutputMode Mode { get; }
    public PrintDecorations PrintDecorations { get; }

    public override void Execute()
    {
        if (FileSystem is null)
            throw new FileSystemNotSpecifiedException();

        if (!FileSystem.IsConnected)
            throw new FileSystemNotConnectedException();

        if (FileSystem.DirectoryInteractionProvider is null)
            throw new FileSystemNotConnectedCorrectlyException();

        if (FileSystem.WorkingDirectory is null)
            throw new FileSystemNotConnectedCorrectlyException();

        PrintDirectory(FileSystem.WorkingDirectory, FileSystem.DirectoryInteractionProvider);
    }

    private void PrintDirectory(string path, IDirectoryInteractionProvider interactionProvider)
    {
        DirectoryComponentComposite directory = interactionProvider.GetDirectory(path);

        IDirectoryTraversal traversal = new FullDirectoryTraversal(directory);
        IDirectoryPrinter printer = new DirectoryPrinter();

        printer.Print(_textWriter, traversal, PrintDecorations, Depth);
    }
}
