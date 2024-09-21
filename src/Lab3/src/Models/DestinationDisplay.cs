using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class DestinationDisplay : IDestination
{
    private readonly IDisplay _display;

    public DestinationDisplay(IDisplay display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));
        _display.SendMessage(message);
    }
}
