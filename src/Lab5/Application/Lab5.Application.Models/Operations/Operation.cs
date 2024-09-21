using System;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

public class Operation
{
    public Operation(double money, OperationType operationType, int cashMacineSerialNumber)
    {
        Money = money;
        OperationType = operationType;
        CashMacineSerialNumber = cashMacineSerialNumber;
    }

    public double Money { get; }
    public OperationType OperationType { get; }
    public int CashMacineSerialNumber { get; }

    public override string ToString()
    {
        return $"{Enum.GetName(OperationType)}:\t{Money}\t[cash machine {CashMacineSerialNumber}]";
    }
}
