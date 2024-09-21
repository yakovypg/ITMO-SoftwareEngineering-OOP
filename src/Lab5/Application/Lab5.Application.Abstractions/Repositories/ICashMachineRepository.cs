using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface ICashMachineRepository
{
    IEnumerable<CashMachine> GetAllCashMachines();
}
