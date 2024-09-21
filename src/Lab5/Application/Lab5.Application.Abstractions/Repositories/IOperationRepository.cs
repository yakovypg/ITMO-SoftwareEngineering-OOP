using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IOperationRepository
{
    IEnumerable<Operation> GetAllUserOperations(string username);
    void AddOperation(string username, OperationType operationType, double money, int cashMachineSerialNumber);
}
