using System;
using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class OrderService
{
    public static Order CreateOrder(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer, nameof(computer));

        var inspector = new ComputerInspector(computer);
        inspector.Inspect();

        return new Order(
            computer,
            inspector.HasNotRecommendedComponentsCombinations(),
            inspector.VerifyPowerSupplyRecommendations());
    }
}
