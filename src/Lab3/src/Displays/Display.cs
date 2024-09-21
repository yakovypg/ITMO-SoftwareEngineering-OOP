using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IEndpoint
{
    public Display(DisplayDriver driver)
    {
        Id = Guid.NewGuid();
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
    }

    public Guid Id { get; }
    public DisplayDriver Driver { get; }

    public virtual void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        Driver.Clear();
        Driver.WriteLine($"Display {Id}: {message}");
    }
}
