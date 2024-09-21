using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class MoveFileCommandExtractor : ICommandExtractor
{
    private readonly MoveFileCommandBuilder _builder;

    public MoveFileCommandExtractor(MoveFileCommandBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Command Extract(CommandData data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));

        if (data.ExtraArguments.Count != 3)
            throw new IncorrectCommandDataException(data);

        string sourcePath = data.ExtraArguments[1];
        string destinationPath = data.ExtraArguments[2];

        return _builder
            .AddSourcePath(sourcePath)
            .AddDestinationDirectoryPath(destinationPath)
            .Build();
    }
}
