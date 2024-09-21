using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class DestinationUser : Destination
{
    private readonly ITextWriter? _logger;

    public DestinationUser(User user, ImportanceFilter? filter = null, ITextWriter? logger = null)
        : base(user, filter)
    {
        _logger = logger;
    }

    public override void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));

        if (Filter is not null && !Filter.Accept(message))
            return;

        Endpoint.ReceiveMessage(message);
        _logger?.WriteLine($"DestinationUser -> {Endpoint.Id}: {message}");
    }
}
