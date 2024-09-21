using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class OperationInfo
{
    public OperationInfo(string username, Operation operation)
    {
        Operation = operation ?? throw new ArgumentNullException(nameof(operation));
        Username = username;
    }

    public string Username { get; }
    public Operation Operation { get; }
}
