using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IEndpoint
{
    public Guid Id { get; }
    void ReceiveMessage(Message message);
}
