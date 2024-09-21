using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Enums;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]
    public void ConnectCommandParsingCorrectness()
    {
        string address = "C:/Testing/Test";
        FileSystemMode mode = FileSystemMode.Local;
        var fileSystem = new LocalFileSystem();

        string inputData = $"connect {address} -m local";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<ConnectCommand>(command);

        var connectCommand = (ConnectCommand)command;

        Assert.Equal(address, connectCommand.Address);
        Assert.Equal(mode, connectCommand.Mode);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void DisconnectCommandParsingCorrectness()
    {
        var fileSystem = new LocalFileSystem();

        string inputData = $"disconnect";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<DisconnectCommand>(command);

        var connectCommand = (DisconnectCommand)command;

        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void GotoCommandParsingCorrectness()
    {
        string path = "G:/Testing/Folder/Subfolder/Test";
        var fileSystem = new LocalFileSystem();

        string inputData = $"tree goto {path}";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<GotoCommand>(command);

        var connectCommand = (GotoCommand)command;

        Assert.Equal(path, connectCommand.Path);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void CopyFileCommandParsingCorrectness()
    {
        string sourcePath = "D:/Testing/Test/file.txt";
        string destinationPath = "D:/Testing/Test/Folder";
        var fileSystem = new LocalFileSystem();

        string inputData = $"file copy {sourcePath} {destinationPath}";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<CopyFileCommand>(command);

        var connectCommand = (CopyFileCommand)command;

        Assert.Equal(sourcePath, connectCommand.SourcePath);
        Assert.Equal(destinationPath, connectCommand.DestinationDirectoryPath);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void MoveFileCommandParsingCorrectness()
    {
        string sourcePath = "D://Testing//Test//file.txt";
        string destinationPath = "D://Testing";
        var fileSystem = new LocalFileSystem();

        string inputData = $"file move {sourcePath} {destinationPath}";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<MoveFileCommand>(command);

        var connectCommand = (MoveFileCommand)command;

        Assert.Equal(sourcePath, connectCommand.SourcePath);
        Assert.Equal(destinationPath, connectCommand.DestinationDirectoryPath);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void RenameFileCommandParsingCorrectness()
    {
        string path = @"C:\Testing\Test\file.txt";
        string newName = "new.txt";
        var fileSystem = new LocalFileSystem();

        string inputData = $"file rename {path} {newName}";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<RenameFileCommand>(command);

        var connectCommand = (RenameFileCommand)command;

        Assert.Equal(path, connectCommand.Path);
        Assert.Equal(newName, connectCommand.NewName);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void DeleteFileCommandParsingCorrectness()
    {
        string path = "E:/Some/Path/file.txt";
        var fileSystem = new LocalFileSystem();

        string inputData = $"file delete {path}";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<DeleteFileCommand>(command);

        var connectCommand = (DeleteFileCommand)command;

        Assert.Equal(path, connectCommand.Path);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void ShowFileCommandParsingCorrectness()
    {
        string path = "C:/Testing/Test";
        OutputMode mode = OutputMode.Console;
        var fileSystem = new LocalFileSystem();

        string inputData = $"file show {path} -m console";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<ShowFileCommand>(command);

        var connectCommand = (ShowFileCommand)command;

        Assert.Equal(path, connectCommand.Path);
        Assert.Equal(mode, connectCommand.Mode);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void ShowDirectoryCommandParsingCorrectness()
    {
        int depth = -1;
        var fileSystem = new LocalFileSystem();

        string inputData = $"tree list -d {depth}";

        var argumentParser = new ArgumentsParser(' ', '-');
        var commandCreator = new ConsoleCommandCreator();

        CommandData commandData = argumentParser.Parse(inputData);
        ICommand command = commandCreator.Create(commandData, fileSystem);

        Assert.IsType<ShowDirectoryCommand>(command);

        var connectCommand = (ShowDirectoryCommand)command;

        Assert.Equal(depth, connectCommand.Depth);
        Assert.Equal(OutputMode.Console, connectCommand.Mode);
        Assert.Equal(fileSystem, connectCommand.FileSystem);
    }

    [Fact]
    public void ComplexCommandParsingCorrectness()
    {
        char argumentStartSymbol = '~';
        char delimiter = '_';

        string intValue = "-12345";
        string uintValue = "1000000";
        string doubleValue = "-1.156";
        string stringValue = "value";

        string intValueKey = $"i";
        string uintValueKey = $"u";
        string doubleValueKey = $"d";
        string stringValueKey = $"s";

        string firstBoolValueKey = $"z";
        string secondBoolValueKey = $"y";

        var keys = new List<string>()
        {
            intValueKey,
            uintValueKey,
            doubleValueKey,
            stringValueKey,
            firstBoolValueKey,
            secondBoolValueKey,
        };

        string firstExtraArgument = "extra1";
        string secondExtraArgument = "extra2";
        string thirdExtraArgument = "extra3";

        var extraArguments = new List<string>()
        {
            firstExtraArgument,
            secondExtraArgument,
            thirdExtraArgument,
        };

        string commandName = "command";

        string inputData =
            $"{commandName}" +
            $"{delimiter}{secondExtraArgument}" +
            $"{delimiter}{argumentStartSymbol}{intValueKey}{delimiter}{intValue}" +
            $"{delimiter}{argumentStartSymbol}{uintValueKey}{delimiter}{uintValue}" +
            $"{delimiter}{argumentStartSymbol}{doubleValueKey}{delimiter}{doubleValue}" +
            $"{delimiter}{delimiter}{firstExtraArgument}" +
            $"{delimiter}{thirdExtraArgument}" +
            $"{delimiter}{delimiter}{delimiter}{argumentStartSymbol}{firstBoolValueKey}" +
            $"{delimiter}{argumentStartSymbol}{stringValueKey}{delimiter}{stringValue}" +
            $"{delimiter}{argumentStartSymbol}{secondBoolValueKey}" +
            $"{delimiter}{delimiter}{delimiter}";

        var argumentParser = new ArgumentsParser(delimiter, argumentStartSymbol);
        CommandData commandData = argumentParser.Parse(inputData);

        Assert.Equal(commandName, commandData.Name);

        var actualExtraArguments = new List<string>(commandData.ExtraArguments);
        extraArguments.Sort();
        actualExtraArguments.Sort();

        Assert.Equal(extraArguments, actualExtraArguments);

        foreach (string key in keys)
        {
            Assert.True(commandData.Arguments.ContainsKey(key));
        }

        Assert.Empty(commandData.Arguments.Keys.Except(keys));

        Assert.Equal(intValue, commandData.Arguments[intValueKey]);
        Assert.Equal(uintValue, commandData.Arguments[uintValueKey]);
        Assert.Equal(doubleValue, commandData.Arguments[doubleValueKey]);
        Assert.Equal(stringValue, commandData.Arguments[stringValueKey]);

        Assert.Equal(string.Empty, commandData.Arguments[firstBoolValueKey]);
        Assert.Equal(string.Empty, commandData.Arguments[secondBoolValueKey]);
    }
}
