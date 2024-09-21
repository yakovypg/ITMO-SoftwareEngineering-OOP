using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class ShowFileCommandExtractor : ICommandExtractor
{
    private readonly ShowFileCommandBuilder _builder;

    public ShowFileCommandExtractor(ShowFileCommandBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Command Extract(CommandData data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));

        if (data.ExtraArguments.Count != 2)
            throw new IncorrectCommandDataException(data);

        string path = data.ExtraArguments[1];

        if (!data.Arguments.TryGetValue(ArgumentsParser.ModeArgument, out string? modeData)
            || !Enum.TryParse(modeData, true, out OutputMode mode))
        {
            throw new IncorrectCommandDataException(data);
        }

        return _builder
            .AddPath(path)
            .AddMode(mode)
            .Build();
    }
}
