using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Machines;

public class CurrentCashMachineService : ICurrentCashMachineService
{
    public CashMachine? CurrentCashMachine { get; set; }
}
