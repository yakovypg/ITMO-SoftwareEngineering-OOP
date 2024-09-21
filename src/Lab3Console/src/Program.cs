using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

var logger = new ConsoleTextWriter();

var displayDriver = new CustomDisplayDriver(logger);
var display = new Display(displayDriver);

var colors = new ConsoleColor[]
{
    ConsoleColor.Red,
    ConsoleColor.Green,
    ConsoleColor.Blue,
};

for (int i = 0; i < colors.Length; ++i)
{
    Console.Write("Enter message: ");

    string body = Console.ReadLine() ?? string.Empty;
    var message = new Message($"Header {i + 1}", body);

    display.Driver.ForegroundColor = colors[i];
    display.ReceiveMessage(message);
}

_ = Console.ReadKey();
