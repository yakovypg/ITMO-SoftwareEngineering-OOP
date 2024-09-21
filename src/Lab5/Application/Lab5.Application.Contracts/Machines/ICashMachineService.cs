using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;

public interface ICashMachineService
{
    IEnumerable<CashMachine> GetAllCashMachines();
}
