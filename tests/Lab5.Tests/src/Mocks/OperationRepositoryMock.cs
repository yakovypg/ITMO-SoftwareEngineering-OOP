using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class OperationRepositoryMock : IOperationRepository
{
    private readonly List<OperationInfo> _operations;

    public OperationRepositoryMock()
    {
        _operations = new List<OperationInfo>();
    }

    public void AddOperation(string username, OperationType operationType, double money, int cashMachineSerialNumber)
    {
        var operation = new Operation(money, operationType, cashMachineSerialNumber);
        var operationInfo = new OperationInfo(username, operation);

        _operations.Add(operationInfo);
    }

    public IEnumerable<Operation> GetAllUserOperations(string username)
    {
        return _operations.Select(t => t.Operation);
    }
}
