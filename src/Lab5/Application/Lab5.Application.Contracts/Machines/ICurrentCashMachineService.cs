using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;

public interface ICurrentCashMachineService
{
    CashMachine? CurrentCashMachine { get; set; }
}
