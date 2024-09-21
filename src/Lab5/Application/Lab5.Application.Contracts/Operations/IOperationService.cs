using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;

public interface IOperationService
{
    IEnumerable<Operation> GetAllUserOperations(string username);
}
