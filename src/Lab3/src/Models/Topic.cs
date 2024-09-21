using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Topic
{
    public Topic(string name, IDestination destination)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Destination = destination ?? throw new ArgumentNullException(nameof(destination));
    }

    public string Name { get; }
    public IDestination Destination { get; }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        Destination.SendMessage(message);
    }
}
