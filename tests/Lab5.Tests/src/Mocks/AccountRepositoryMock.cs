using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Interactions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class AccountRepositoryMock : IAccountRepository, IAccountMoneyInteraction
{
    private readonly Dictionary<string, Account> _accounts; // Username -> Account

    public AccountRepositoryMock()
    {
        _accounts = new Dictionary<string, Account>();
    }

    public void AddAccount(string username, double money)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        if (_accounts.ContainsKey(username))
            throw new InvalidOperationException("User already has an account");

        _accounts.Add(username, new Account(money));
    }

    public void AddAccount(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        AddAccount(username, 0);
    }

    public Account? FindAccount(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        return _accounts.TryGetValue(username, out Account? account)
            ? account
            : null;
    }

    public void DepositMoney(string username, double money)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        if (!_accounts.TryGetValue(username, out Account? account) || account is null)
            throw new KeyNotFoundException();

        _accounts[username] = new Account(account.Money + money);
    }

    public void WithdrawMoney(string username, double money)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        DepositMoney(username, -money);
    }
}
