using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Operations;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;

    public OperationService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository
            ?? throw new ArgumentNullException(nameof(operationRepository));
    }

    public IEnumerable<Operation> GetAllUserOperations(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        return _operationRepository.GetAllUserOperations(username);
    }
}
