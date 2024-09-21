using System;
using Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messangers;

public class SimpleMessenger : IEndpoint, IMessenger
{
    private readonly ITextWriter _out;
    private readonly ITextWriter? _logger;

    public SimpleMessenger()
        : this(new ConsoleTextWriter())
    {
    }

    public SimpleMessenger(ITextWriter messengerOut, ImportanceFilter? filter = null, ITextWriter? logger = null)
    {
        _out = messengerOut ?? throw new ArgumentNullException(nameof(messengerOut));
        _logger = logger;

        Filter = filter ?? throw new ArgumentNullException(nameof(filter));
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public ImportanceFilter? Filter { get; }

    public virtual void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _out.WriteLine($"Messenger {Id}: {message}");
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));

        if (Filter is not null && !Filter.Accept(message))
            return;

        ReceiveMessage(message);
        _logger?.WriteLine($"DestinationMessenger -> {Id}: {message}");
    }
}
