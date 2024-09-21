using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Machines;

public class CashMachineService : ICashMachineService
{
    private readonly ICashMachineRepository _cashMachineRepository;

    public CashMachineService(ICashMachineRepository cashMachineRepository)
    {
        _cashMachineRepository = cashMachineRepository
            ?? throw new ArgumentNullException(nameof(cashMachineRepository));
    }

    public IEnumerable<CashMachine> GetAllCashMachines()
    {
        return _cashMachineRepository.GetAllCashMachines();
    }
}
