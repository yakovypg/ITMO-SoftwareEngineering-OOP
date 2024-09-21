using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab3.Messangers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void MessegeReceivedInUnreadStatus()
    {
        var user = new User();
        var destinationUser = new DestinationUser(user);
        var topic = new Topic("Topic", destinationUser);

        const int messagesCount = 10;
        var messages = new Message[messagesCount];

        for (int i = 0; i < messagesCount; ++i)
        {
            var message = new Message($"Header {i}", $"Body {i}");

            messages[i] = message;
            topic.ReceiveMessage(message);

            Assert.True(user.Messages.ContainsKey(message));
            Assert.False(user.Messages[message]);
        }
    }

    [Fact]
    public void ChangeUnreadMessageStatus()
    {
        var user = new User();
        var destinationUser = new DestinationUser(user);
        var topic = new Topic("Topic", destinationUser);

        const int messagesCount = 10;

        for (int i = 0; i < messagesCount; ++i)
        {
            var message = new Message($"Header {i}", $"Body {i}");
            topic.ReceiveMessage(message);

            Assert.False(user.Messages[message]);
            user.MarkMessageAsReaded(message);
            Assert.True(user.Messages[message]);
        }
    }

    [Fact]
    public void ChangeReadMessageStatus()
    {
        var user = new User();
        var destinationUser = new DestinationUser(user);
        var topic = new Topic("Topic", destinationUser);

        var message = new Message($"Header", $"Body");

        topic.ReceiveMessage(message);
        user.MarkMessageAsReaded(message);

        Assert.True(user.Messages[message]);
        Assert.Throws<MessageReadedException>(() => user.MarkMessageAsReaded(message));
    }

    [Fact]
    public void ChangeNotRecievedMessageStatus()
    {
        var user = new User();
        var message = new Message($"Header", $"Body");

        Assert.Throws<UserNotRecieveMessageException>(() => user.MarkMessageAsReaded(message));
    }

    [Fact]
    public void MessageFilteringCorrectness()
    {
        ImportanceFilter importantMessagesFilter =
            new OnlyImportantMessagesFilterCreator().CreateFilter();

        ImportanceFilter unimportantMessagesFilter =
            new OnlyUnimportantMessagesFilterCreator().CreateFilter();

        var bossUser = new UserMock();
        var bossDisplay = new DisplayMock(importantMessagesFilter);
        var bossMesseneger = new MessengerMock(null, importantMessagesFilter);

        var destinationBossUser = new DestinationUser(bossUser, importantMessagesFilter);
        var destinationBossDisplay = new DestinationDisplay(bossDisplay);
        var destinationBossMessenger = new DestinationMessenger(bossMesseneger);

        var employeeUser = new UserMock();
        var employeeDisplay = new DisplayMock(unimportantMessagesFilter);
        var employeeMesseneger = new MessengerMock(null, unimportantMessagesFilter);

        var destinationEmployeeUser = new DestinationUser(employeeUser, unimportantMessagesFilter);
        var destinationEmployeeDisplay = new DestinationDisplay(employeeDisplay);
        var destinationEmployeeMessenger = new DestinationMessenger(employeeMesseneger);

        var bossUserTopic = new Topic("User", destinationBossUser);
        var bossDisplayTopic = new Topic("Display", destinationBossDisplay);
        var bossMessengerTopic = new Topic("Messenger", destinationBossMessenger);

        var employeeUserTopic = new Topic("User", destinationEmployeeUser);
        var employeeDisplayTopic = new Topic("Display", destinationEmployeeDisplay);
        var employeeMessengerTopic = new Topic("Messenger", destinationEmployeeMessenger);

        const int unimportantMessagesCount = 10;
        const int importantMessagesCount = 5;
        const int normalMessagesCount = 7;

        for (int i = 0; i < unimportantMessagesCount; ++i)
        {
            var message = new Message("Unimportant", $"Body {i}", MessagePriority.Lowest);

            bossUserTopic.ReceiveMessage(message);
            bossDisplayTopic.ReceiveMessage(message);
            bossMessengerTopic.ReceiveMessage(message);

            employeeUserTopic.ReceiveMessage(message);
            employeeDisplayTopic.ReceiveMessage(message);
            employeeMessengerTopic.ReceiveMessage(message);
        }

        for (int i = 0; i < importantMessagesCount; ++i)
        {
            var message = new Message("Important", $"Body {i}", MessagePriority.Higest);

            bossUserTopic.ReceiveMessage(message);
            bossDisplayTopic.ReceiveMessage(message);
            bossMessengerTopic.ReceiveMessage(message);

            employeeUserTopic.ReceiveMessage(message);
            employeeDisplayTopic.ReceiveMessage(message);
            employeeMessengerTopic.ReceiveMessage(message);
        }

        for (int i = 0; i < normalMessagesCount; ++i)
        {
            var message = new Message("Normal", $"Body {i}", MessagePriority.Normal);

            bossUserTopic.ReceiveMessage(message);
            bossDisplayTopic.ReceiveMessage(message);
            bossMessengerTopic.ReceiveMessage(message);

            employeeUserTopic.ReceiveMessage(message);
            employeeDisplayTopic.ReceiveMessage(message);
            employeeMessengerTopic.ReceiveMessage(message);
        }

        Assert.Equal(importantMessagesCount, bossUser.ReceivedMessages);
        Assert.Equal(importantMessagesCount, bossDisplay.ReceivedMessages);
        Assert.Equal(importantMessagesCount, bossMesseneger.ReceivedMessages);

        Assert.Equal(unimportantMessagesCount, employeeUser.ReceivedMessages);
        Assert.Equal(unimportantMessagesCount, employeeDisplay.ReceivedMessages);
        Assert.Equal(unimportantMessagesCount, employeeMesseneger.ReceivedMessages);
    }

    [Fact]
    public void LoggingCorrectness()
    {
        var userLogger = new ConsoleTextWriterMock();
        var displayLogger = new ConsoleTextWriterMock();
        var messengerLogger = new ConsoleTextWriterMock();
        var displayDriverOut = new ConsoleTextWriterMock();

        ImportanceFilter filter = new OnlyImportantMessagesFilterCreator().CreateFilter();

        var user = new User();
        var messeneger = new SimpleMessenger(new ConsoleTextWriterMock(), filter, messengerLogger);

        var displayDriver = new CustomDisplayDriverMock(displayDriverOut);
        var display = new ConsoleDisplay(displayDriver, filter, displayLogger);

        var destinationUser = new DestinationUser(user, filter, userLogger);
        var destinationDisplay = new DestinationDisplay(display);
        var destinationMessenger = new DestinationMessenger(messeneger);

        var userTopic = new Topic("User", destinationUser);
        var displayTopic = new Topic("Display", destinationDisplay);
        var messengerTopic = new Topic("Messenger", destinationMessenger);

        const int unimportantMessagesCount = 9;
        const int importantMessagesCount = 7;

        for (int i = 0; i < unimportantMessagesCount; ++i)
        {
            var message = new Message("Unimportant", $"Body {i}", MessagePriority.Lowest);

            userTopic.ReceiveMessage(message);
            displayTopic.ReceiveMessage(message);
            messengerTopic.ReceiveMessage(message);
        }

        for (int i = 0; i < importantMessagesCount; ++i)
        {
            var message = new Message("Important", $"Body {i}", MessagePriority.Higest);

            userTopic.ReceiveMessage(message);
            displayTopic.ReceiveMessage(message);
            messengerTopic.ReceiveMessage(message);
        }

        Assert.Equal(importantMessagesCount, userLogger.WriteLineCallsNumber);
        Assert.Equal(0, userLogger.WriteCallsNumber);
        Assert.Equal(0, userLogger.ClearCallsNumber);
        Assert.True(userLogger.Output.Length > 0);

        Assert.Equal(importantMessagesCount, displayLogger.WriteLineCallsNumber);
        Assert.Equal(0, displayLogger.WriteCallsNumber);
        Assert.Equal(0, displayLogger.ClearCallsNumber);
        Assert.True(displayLogger.Output.Length > 0);

        Assert.Equal(importantMessagesCount, displayDriverOut.WriteLineCallsNumber);
        Assert.Equal(0, displayDriverOut.WriteCallsNumber);
        Assert.Equal(importantMessagesCount, displayDriverOut.ClearCallsNumber);
        Assert.True(displayDriverOut.Output.Length > 0);
        Assert.Single(displayDriverOut.Output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));

        Assert.Equal(importantMessagesCount, displayDriver.ClearCallsNumber);
        Assert.Equal(importantMessagesCount, displayDriver.WriteCallsNumber);

        Assert.Equal(importantMessagesCount, messengerLogger.WriteLineCallsNumber);
        Assert.Equal(0, messengerLogger.WriteCallsNumber);
        Assert.Equal(0, messengerLogger.ClearCallsNumber);
        Assert.True(messengerLogger.Output.Length > 0);
    }

    [Fact]
    public void LoggingToFileCorrectness()
    {
        const string logFilePath = "test_log.txt";

        if (File.Exists(logFilePath))
            File.Delete(logFilePath);

        var logger = new FileTextWriter(logFilePath);

        var user = new User();
        var destination = new DestinationUser(user, null, logger);
        var topic = new Topic("User", destination);

        var firstMessage = new Message("Important", $"Body 1", MessagePriority.Higest);
        var secondMessage = new Message("Normal", $"Body 2", MessagePriority.Normal);
        var thirdMessage = new Message("Unimportant", $"Body 3", MessagePriority.Lowest);

        topic.ReceiveMessage(firstMessage);
        topic.ReceiveMessage(secondMessage);
        topic.ReceiveMessage(thirdMessage);

        string[] output = File.ReadAllLines(logFilePath);
        string prefix = $"DestinationUser -> {user.Id}: ";

        string[] expectedOutputLines = new string[]
        {
            $"{prefix}{firstMessage}",
            $"{prefix}{secondMessage}",
            $"{prefix}{thirdMessage}",
        };

        Assert.Equal(expectedOutputLines, output);
    }

    [Fact]
    public void MessengerMessegeReceivingCorrectness()
    {
        var messengerOut = new ConsoleTextWriterMock();
        var messengerLogger = new ConsoleTextWriterMock();

        ImportanceFilter filter = new OnlyUnimportantMessagesFilterCreator().CreateFilter();

        var messenger = new MessengerMock(messengerOut, filter, messengerLogger);
        var destination = new DestinationMessenger(messenger);
        var topic = new Topic("Messenger", destination);

        var firstUnimportantMessage = new Message("Unimportant", $"Body 1", MessagePriority.Lowest);
        var secondUnimportantMessage = new Message("Unimportant", $"Body 2", MessagePriority.Lowest);
        var thirdUnimportantMessage = new Message("Unimportant", $"Body 3", MessagePriority.Lowest);

        var normalMessage = new Message("Normal", $"Body 5", MessagePriority.Normal);
        var aboveNormalMessage = new Message("AboveNormal", $"Body 7", MessagePriority.AboveNormal);
        var importantMessage = new Message("Important", $"Body 3", MessagePriority.Higest);

        topic.ReceiveMessage(firstUnimportantMessage);
        topic.ReceiveMessage(normalMessage);
        topic.ReceiveMessage(secondUnimportantMessage);
        topic.ReceiveMessage(aboveNormalMessage);
        topic.ReceiveMessage(thirdUnimportantMessage);
        topic.ReceiveMessage(importantMessage);

        const int expectedReceivedMessages = 3;

        Assert.Equal(expectedReceivedMessages, messengerLogger.WriteLineCallsNumber);
        Assert.Equal(0, messengerLogger.WriteCallsNumber);
        Assert.Equal(0, messengerLogger.ClearCallsNumber);

        Assert.Equal(expectedReceivedMessages, messenger.ReceivedMessages);

        Assert.Equal(expectedReceivedMessages, messengerOut.WriteLineCallsNumber);
        Assert.Equal(0, messengerOut.WriteCallsNumber);
        Assert.Equal(0, messengerOut.ClearCallsNumber);

        string output = messengerOut.Output;
        string[] outputLines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        string prefix = $"Messenger {messenger.Id}: ";

        string[] expectedOutputLines = new string[]
        {
            $"{prefix}{firstUnimportantMessage}",
            $"{prefix}{secondUnimportantMessage}",
            $"{prefix}{thirdUnimportantMessage}",
        };

        Assert.Equal(expectedOutputLines, outputLines);
    }

    [Fact]
    public void DisplayColorCorrectness()
    {
        var logger = new ConsoleTextWriterMock();
        var customDriver = new CustomDisplayDriverMock(logger);
        var displayDriver = new InformativeDisplayDriver(customDriver, logger);

        var display = new ConsoleDisplay(displayDriver);
        var destination = new DestinationDisplay(display);
        var topic = new Topic("Display", destination);

        var firstMessage = new Message("Header 1", $"Body 1");
        var secondMessage = new Message("Header 2", $"Body 2");
        var thirdMessage = new Message("Header 3", $"Body 3");

        ConsoleColor firstColor = ConsoleColor.Red;
        ConsoleColor secondColor = ConsoleColor.Green;
        ConsoleColor thirdColor = ConsoleColor.Blue;

        string? firstColorName = Enum.GetName(typeof(ConsoleColor), firstColor);
        string? secondColorName = Enum.GetName(typeof(ConsoleColor), secondColor);
        string? thirdColorName = Enum.GetName(typeof(ConsoleColor), thirdColor);

        display.Driver.ForegroundColor = firstColor;
        topic.ReceiveMessage(firstMessage);

        string expectedFirstOutputLine = $"[{firstColorName}] Display {display.Id}: {firstMessage}";
        Assert.Equal(expectedFirstOutputLine, logger.Output.ReplaceLineEndings(string.Empty));

        display.Driver.ForegroundColor = secondColor;
        topic.ReceiveMessage(secondMessage);

        string expectedSecondOutputLine = $"[{secondColorName}] Display {display.Id}: {secondMessage}";
        Assert.Equal(expectedSecondOutputLine, logger.Output.ReplaceLineEndings(string.Empty));

        display.Driver.ForegroundColor = thirdColor;
        topic.ReceiveMessage(thirdMessage);

        string expectedThirdOutputLine = $"[{thirdColorName}] Display {display.Id}: {thirdMessage}";
        Assert.Equal(expectedThirdOutputLine, logger.Output.ReplaceLineEndings(string.Empty));
    }

    [Fact]
    public void GroupMessegeReceivingCorrectness()
    {
        const int usersCount = 10;
        var users = new User[usersCount];

        for (int i = 0; i < usersCount; ++i)
        {
            users[i] = new User();
        }

        var destinationGroup = new DestinationGroup(users);
        var topic = new Topic("Topic", destinationGroup);

        const int messagesCount = 10;
        var messages = new Message[messagesCount];

        for (int i = 0; i < usersCount; ++i)
        {
            var message = new Message($"Header {i}", $"Body {i}");

            messages[i] = message;
            topic.ReceiveMessage(message);
        }

        var messageComparer = new MessageIdComparer();
        Array.Sort(messages, messageComparer);

        for (int i = 0; i < usersCount; ++i)
        {
            Message[] userMessages = users[i].Messages.Keys.ToArray();
            Array.Sort(userMessages, messageComparer);

            Assert.Equal(messages, userMessages);
        }
    }
}
