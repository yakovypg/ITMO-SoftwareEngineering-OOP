using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Infrastructure;
internal class ShowDirectoryCommandExtractor : ICommandExtractor
{
    private readonly ShowDirectoryCommandBuilder _builder;

    public ShowDirectoryCommandExtractor(ShowDirectoryCommandBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Command Extract(CommandData data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));

        if (!data.Arguments.TryGetValue(ArgumentsParser.DepthArgument, out string? depthData)
            || !int.TryParse(depthData, out int depth))
        {
            throw new IncorrectCommandDataException(data);
        }

        return _builder
            .AddDepth(depth)
            .AddPrintDecorations(new PrintDecorations())
            .AddOutputMode(OutputMode.Console)
            .Build();
    }
}
