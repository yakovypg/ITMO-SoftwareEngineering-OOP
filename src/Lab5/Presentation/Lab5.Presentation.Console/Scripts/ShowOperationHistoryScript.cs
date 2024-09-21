using System;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;

public class ShowOperationHistoryScript : Script
{
    private readonly IOperationService _operationService;
    private readonly ICurrentUserService _currentUserService;

    public ShowOperationHistoryScript(
        IOperationService operationService,
        ICurrentUserService currentUserService,
        IConsole? console = null)
        : base(console ?? new InteractiveConsole())
    {
        _operationService = operationService
            ?? throw new ArgumentNullException(nameof(operationService));

        _currentUserService = currentUserService
            ?? throw new ArgumentNullException(nameof(currentUserService));
    }

    public override string Description => "Show operations";

    public override void Execute()
    {
        ArgumentNullException.ThrowIfNull(_currentUserService.CurrentUser, nameof(_currentUserService.CurrentUser));

        Operation[] operations = _operationService
            .GetAllUserOperations(_currentUserService.CurrentUser.Username)
            .ToArray();

        if (operations.Length == 0)
        {
            Console.WriteLine("Operations not found");
            return;
        }

        var table = new Table();
        table.AddColumn("N");
        table.AddColumn("Type");
        table.AddColumn("Sum");
        table.AddColumn("Cash machine");

        for (int i = 0; i < operations.Length; ++i)
        {
            Operation operation = operations[i];

            table.AddRow(
                $"{i + 1}",
                Enum.GetName(operation.OperationType) ?? string.Empty,
                operation.Money.ToString(CultureInfo.InvariantCulture),
                operation.CashMacineSerialNumber.ToString(CultureInfo.InvariantCulture));
        }

        Console.Write(table);
    }
}
