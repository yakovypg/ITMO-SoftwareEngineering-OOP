using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public abstract class Destination : IDestination
{
    protected Destination(IEndpoint endpoint, ImportanceFilter? filter)
    {
        Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        Filter = filter;
    }

    public IEndpoint Endpoint { get; }
    public ImportanceFilter? Filter { get; }

    public abstract void SendMessage(Message message);
}
