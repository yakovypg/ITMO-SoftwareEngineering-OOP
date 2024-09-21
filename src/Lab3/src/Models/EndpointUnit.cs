using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public abstract class EndpointUnit : IEndpoint
{
    protected EndpointUnit()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public abstract void ReceiveMessage(Message message);
    public abstract void Add(EndpointUnit unit);
    public abstract void Remove(EndpointUnit unit);
}
