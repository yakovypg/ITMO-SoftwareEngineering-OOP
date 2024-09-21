using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class DestinationGroup : EndpointUnit, IDestination
{
    private readonly ITextWriter? _logger;
    private readonly List<EndpointUnit> _children;

    public DestinationGroup(IEnumerable<EndpointUnit> children, ImportanceFilter? filter = null, ITextWriter? logger = null)
    {
        ArgumentNullException.ThrowIfNull(children, nameof(children));

        _logger = logger;
        _children = new List<EndpointUnit>(children);

        Filter = filter;
    }

    public ImportanceFilter? Filter { get; }
    public IReadOnlyList<EndpointUnit> Children => _children;

    public override void ReceiveMessage(Message message)
    {
        SendMessage(message);
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));

        if (Filter is not null && !Filter.Accept(message))
            return;

        foreach (EndpointUnit child in _children)
        {
            child.ReceiveMessage(message);
        }

        IEnumerable<string> endpointIds = _children.Select(t => t.Id.ToString());
        string endpointIdsPresenter = string.Join(", ", endpointIds);

        _logger?.WriteLine($"DestinationGroup -> {endpointIdsPresenter}: {message}");
    }

    public override void Add(EndpointUnit unit)
    {
        _children.Add(unit);
    }

    public override void Remove(EndpointUnit unit)
    {
        _ = _children.Remove(unit);
    }
}
