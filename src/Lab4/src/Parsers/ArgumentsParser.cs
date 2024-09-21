using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ArgumentsParser
{
    public ArgumentsParser(char delimiter = ' ', char argumentStartSymbol = '-')
    {
        Delimiter = delimiter;
        ArgumentStartSymbol = argumentStartSymbol;
    }

    public static string ModeArgument => "m";
    public static string DepthArgument => "d";

    public char Delimiter { get; }
    public char ArgumentStartSymbol { get; }

    public CommandData Parse(string data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));

        string[] parts = data.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);
        string commandName = parts[0];

        if (parts.Length == 1)
            return new CommandData(commandName);

        var extraArguments = new List<string>();
        var arguments = new Dictionary<string, string>();
        var partsQueue = new Queue<string>(parts[1..]);

        while (partsQueue.Count > 0)
        {
            string currPart = partsQueue.Dequeue();

            if (!IsArgumentName(currPart))
            {
                extraArguments.Add(currPart);
                continue;
            }

            if (currPart.Length < 2)
                throw new IncorrectCommandException(data, null, null);

            string argumentName = currPart[1..];

            string argumentValue = partsQueue.Count > 0 && !IsArgumentName(partsQueue.Peek())
                ? partsQueue.Dequeue()
                : string.Empty;

            arguments[argumentName] = argumentValue;
        }

        return new CommandData(commandName, extraArguments, arguments);
    }

    private bool IsArgumentName(string data)
    {
        return data.StartsWith(ArgumentStartSymbol) && !double.TryParse(data, out _);
    }
}
