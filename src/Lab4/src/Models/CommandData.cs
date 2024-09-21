using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class CommandData
{
    private readonly List<string> _extraArguments;
    private readonly Dictionary<string, string> _arguments;

    public CommandData(string name)
        : this(name, Array.Empty<string>(), new Dictionary<string, string>())
    {
    }

    public CommandData(string name, IEnumerable<string> extraArguments, Dictionary<string, string> arguments)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentNullException.ThrowIfNull(extraArguments, nameof(extraArguments));
        ArgumentNullException.ThrowIfNull(arguments, nameof(arguments));

        _extraArguments = new List<string>(extraArguments);
        _arguments = new Dictionary<string, string>(arguments);

        Name = name;
    }

    public string Name { get; }

    public IReadOnlyList<string> ExtraArguments => _extraArguments;
    public IReadOnlyDictionary<string, string> Arguments => _arguments;
}
