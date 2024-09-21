using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Interactions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IOperationRepository _operationRepository;
    private readonly IAccountMoneyInteraction _accountMoneyInteraction;
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentAccountService _currentAccountService;

    public AccountService(
        IOperationRepository operationRepository,
        IAccountMoneyInteraction accountMoneyInteraction,
        IAccountRepository accountRepository,
        ICurrentAccountService currentAccountService)
    {
        _operationRepository = operationRepository
            ?? throw new ArgumentNullException(nameof(operationRepository));

        _accountMoneyInteraction = accountMoneyInteraction
            ?? throw new ArgumentNullException(nameof(accountMoneyInteraction));

        _accountRepository = accountRepository
            ?? throw new ArgumentNullException(nameof(accountRepository));

        _currentAccountService = currentAccountService
            ?? throw new ArgumentNullException(nameof(currentAccountService));
    }

    public void DepositMoneyToAccount(string username, double money, int cashMachineSerialNumber)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        _accountMoneyInteraction.DepositMoney(username, money);
        _operationRepository.AddOperation(username, OperationType.Deposit, money, cashMachineSerialNumber);
        _currentAccountService.CurrentAccount = _accountRepository.FindAccount(username);
    }

    public void WithdrawMoneyFromAccount(string username, double money, int cashMachineSerialNumber)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        Account account = _accountRepository.FindAccount(username)
            ?? throw new KeyNotFoundException();

        if (account.Money < money)
            throw new ArgumentOutOfRangeException(nameof(money), "There are insufficient money in the account");

        _accountMoneyInteraction.WithdrawMoney(username, money);
        _operationRepository.AddOperation(username, OperationType.Withdraw, money, cashMachineSerialNumber);
        _currentAccountService.CurrentAccount = _accountRepository.FindAccount(username);
    }
}
