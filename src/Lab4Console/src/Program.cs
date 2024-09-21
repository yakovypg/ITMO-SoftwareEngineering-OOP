using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

const string exitCommand = "exit";

var argumentParser = new ArgumentsParser(' ', '-');
var commandCreator = new ConsoleCommandCreator();
var fileSystem = new LocalFileSystem();

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

while (true)
{
    Console.Write($"{fileSystem.WorkingDirectory}> ");
    string? inputData = Console.ReadLine();

    if (inputData == exitCommand)
        break;

    if (string.IsNullOrEmpty(inputData))
        continue;

    TryPerformAction(() =>
    {
        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        command.Execute();
    });

    Console.WriteLine();
}

static void TryPerformAction(Action action)
{
#pragma warning disable CA1031 // Do not catch general exception types
    try
    {
        action?.Invoke();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
#pragma warning restore CA1031 // Do not catch general exception types
}
