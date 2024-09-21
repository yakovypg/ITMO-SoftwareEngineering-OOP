using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ConsoleCommandExtractorFactory : CommandExtractorFactory
{
    public override ICommandExtractor CreateSimpleCommandExtractor(CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(commandData, nameof(commandData));

        return commandData.Name switch
        {
            "connect" => new ConnectCommandExtractor(new ConnectCommandBuilder()),
            "disconnect" => new DisconnectCommandExtractor(new DisconnectCommandBuilder()),

            _ => throw new UnknownCommandException(commandData.Name, null, null),
        };
    }

    public override ICommandExtractor CreateComplexCommandExtractor(CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(commandData, nameof(commandData));

        string complexName = commandData.ExtraArguments.Count > 0
            ? $"{commandData.Name} {commandData.ExtraArguments[0]}"
            : commandData.Name;

        return complexName switch
        {
            "tree goto" => new GotoCommandExtractor(new GotoCommandBuilder()),
            "tree list" => new ShowDirectoryCommandExtractor(new ShowDirectoryCommandBuilder()),
            "file show" => new ShowFileCommandExtractor(new ShowFileCommandBuilder()),
            "file move" => new MoveFileCommandExtractor(new MoveFileCommandBuilder()),
            "file copy" => new CopyFileCommandExtractor(new CopyFileCommandBuilder()),
            "file delete" => new DeleteFileCommandExtractor(new DeleteFileCommandBuilder()),
            "file rename" => new RenameFileCommandExtractor(new RenameFileCommandBuilder()),

            _ => throw new UnknownCommandException(complexName, null, null),
        };
    }
}
