using Itmo.ObjectOrientedProgramming.Lab2.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class ComputerComponentsService
{
    static ComputerComponentsService()
    {
        Repository = new ComputerComponentsRepository();
    }

    public static IComputerComponentsRepository Repository { get; }
}
