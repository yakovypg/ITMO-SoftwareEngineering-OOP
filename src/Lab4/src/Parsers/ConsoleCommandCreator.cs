using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ConsoleCommandCreator : CommandCreator
{
    public override Command Create(CommandData commandData, FileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(commandData, nameof(commandData));
        ArgumentNullException.ThrowIfNull(fileSystem, nameof(fileSystem));

        _ = TryGetComplexCommandExtractor(commandData, out ICommandExtractor? complexCommandExtractor);
        _ = TryGetSimpleCommandExtractor(commandData, out ICommandExtractor? simpleCommandExtractor);

        Command command = complexCommandExtractor is not null
            ? complexCommandExtractor.Extract(commandData)
            : simpleCommandExtractor is not null
            ? simpleCommandExtractor.Extract(commandData)
            : throw new UnknownCommandException(commandData.Name, null, null);

        command.FileSystem = fileSystem;

        return command;
    }

    private static bool TryGetComplexCommandExtractor(CommandData commandData, out ICommandExtractor? extractor)
    {
        ArgumentNullException.ThrowIfNull(commandData, nameof(commandData));

        try
        {
            var factory = new ConsoleCommandExtractorFactory();
            extractor = factory.CreateComplexCommandExtractor(commandData);
            return true;
        }
        catch (UnknownCommandException)
        {
            extractor = null;
            return false;
        }
    }

    private static bool TryGetSimpleCommandExtractor(CommandData commandData, out ICommandExtractor? extractor)
    {
        ArgumentNullException.ThrowIfNull(commandData, nameof(commandData));

        try
        {
            var factory = new ConsoleCommandExtractorFactory();
            extractor = factory.CreateSimpleCommandExtractor(commandData);
            return true;
        }
        catch (UnknownCommandException)
        {
            extractor = null;
            return false;
        }
    }
}
