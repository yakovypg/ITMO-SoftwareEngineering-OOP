using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class ConnectCommandExtractor : ICommandExtractor
{
    private readonly ConnectCommandBuilder _builder;

    public ConnectCommandExtractor(ConnectCommandBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Command Extract(CommandData data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));

        if (data.ExtraArguments.Count != 1)
            throw new IncorrectCommandDataException(data);

        string address = data.ExtraArguments[0];

        if (!data.Arguments.TryGetValue(ArgumentsParser.ModeArgument, out string? modeData)
            || !Enum.TryParse(modeData, true, out FileSystemMode mode))
        {
            throw new IncorrectCommandDataException(data);
        }

        return _builder
            .AddAddress(address)
            .AddMode(mode)
            .Build();
    }
}
