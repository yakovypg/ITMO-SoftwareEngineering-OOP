using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class SelectCashMachineScript : Script
{
    private readonly ICashMachineService _cashMachineService;
    private readonly ICurrentCashMachineService _currentCashMachineService;

    public SelectCashMachineScript(
        ICashMachineService cashMachineService,
        ICurrentCashMachineService currentCashMachineService,
        IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _cashMachineService = cashMachineService
            ?? throw new ArgumentNullException(nameof(cashMachineService));

        _currentCashMachineService = currentCashMachineService
            ?? throw new ArgumentNullException(nameof(currentCashMachineService));
    }

    public override string Description => "Select cash machine";

    public override void Execute()
    {
        IEnumerable<CashMachine> cashMachines = _cashMachineService.GetAllCashMachines();

        if (!cashMachines.Any())
        {
            Console.WriteLine("No cash machines");
            return;
        }

        CashMachine selectedCashMahine = Console.MakeChoice(
            choices: cashMachines,
            title: "Select cash machine:",
            converter: t => t.SerialNumber.ToString(CultureInfo.InvariantCulture));

        _currentCashMachineService.CurrentCashMachine = selectedCashMahine;

        Console.WriteLine($"Selected cash machine: {selectedCashMahine.SerialNumber}");
    }
}
