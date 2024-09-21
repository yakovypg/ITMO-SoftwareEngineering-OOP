using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class RenameFileCommandExtractor : ICommandExtractor
{
    private readonly RenameFileCommandBuilder _builder;

    public RenameFileCommandExtractor(RenameFileCommandBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Command Extract(CommandData data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));

        if (data.ExtraArguments.Count != 3)
            throw new IncorrectCommandDataException(data);

        string path = data.ExtraArguments[1];
        string newName = data.ExtraArguments[2];

        return _builder
            .AddPath(path)
            .AddNewName(newName)
            .Build();
    }
}
