using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class ConsoleDisplay : Display, IDisplay
{
    private readonly ITextWriter? _logger;

    public ConsoleDisplay(DisplayDriver driver, ImportanceFilter? filter = null, ITextWriter? logger = null)
        : base(driver)
    {
        _logger = logger;
        Filter = filter;
    }

    public ImportanceFilter? Filter { get; }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));

        if (Filter is not null && !Filter.Accept(message))
            return;

        ReceiveMessage(message);
        _logger?.WriteLine($"DestinationDisplay -> {Id}: {message}");
    }
}
