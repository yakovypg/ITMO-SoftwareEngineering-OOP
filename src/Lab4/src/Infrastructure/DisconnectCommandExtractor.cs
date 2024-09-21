using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;

public class DisconnectCommandExtractor : ICommandExtractor
{
    private readonly DisconnectCommandBuilder _builder;

    public DisconnectCommandExtractor(DisconnectCommandBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Command Extract(CommandData data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));
        return _builder.Build();
    }
}
