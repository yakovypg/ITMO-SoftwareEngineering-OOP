using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.IO;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void DepositMoneyCorrectness()
    {
        const int sourceMoney = 1000;
        const int depositAmount = 150;
        const int expectedMoney = sourceMoney + depositAmount;

        const string userName = "user1";

        IConsole consoleMock = Substitute.For<IConsole>();
        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(depositAmount);

        var accountRepository = new AccountRepositoryMock();
        accountRepository.AddAccount(userName, sourceMoney);
        accountRepository.AddAccount("user2");
        accountRepository.AddAccount("user3");

        var currentAccountService = new CurrentAccountService()
        {
            CurrentAccount = accountRepository.FindAccount(userName),
        };

        var currentUserService = new CurrentUserService()
        {
            CurrentUser = new User(userName, UserRole.Client),
        };

        var currentCashMachineService = new CurrentCashMachineService()
        {
            CurrentCashMachine = new CashMachine(1000300),
        };

        var operationRepositoryMock = new OperationRepositoryMock();

        var accountService = new AccountService(
            operationRepositoryMock,
            accountRepository,
            accountRepository,
            currentAccountService);

        var depositMoneyScript = new DepositMoneyToAccountScript(
            accountService,
            currentUserService,
            currentCashMachineService,
            consoleMock);

        depositMoneyScript.Execute();

        Account? actualAccount = accountRepository.FindAccount(userName);

        Assert.NotNull(actualAccount);
        Assert.Equal(expectedMoney, actualAccount.Money);
    }

    [Fact]
    public void WithdrawPossibleAmountOfMoneyCorrectness()
    {
        const int sourceMoney = 1000;
        const int withdrawAmount = 150;
        const int expectedMoney = sourceMoney - withdrawAmount;

        const string userName = "user1";

        IConsole consoleMock = Substitute.For<IConsole>();
        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(withdrawAmount);

        var accountRepository = new AccountRepositoryMock();
        accountRepository.AddAccount(userName, sourceMoney);
        accountRepository.AddAccount("user2");
        accountRepository.AddAccount("user3");

        var currentAccountService = new CurrentAccountService()
        {
            CurrentAccount = accountRepository.FindAccount(userName),
        };

        var currentUserService = new CurrentUserService()
        {
            CurrentUser = new User(userName, UserRole.Client),
        };

        var currentCashMachineService = new CurrentCashMachineService()
        {
            CurrentCashMachine = new CashMachine(1000300),
        };

        var operationRepositoryMock = new OperationRepositoryMock();

        var accountService = new AccountService(
            operationRepositoryMock,
            accountRepository,
            accountRepository,
            currentAccountService);

        var withdrawMoneyScript = new WithdrawMoneyFromAccountScript(
            accountService,
            currentUserService,
            currentCashMachineService,
            consoleMock);

        withdrawMoneyScript.Execute();

        Account? actualAccount = accountRepository.FindAccount(userName);

        Assert.NotNull(actualAccount);
        Assert.Equal(expectedMoney, actualAccount.Money);
    }

    [Fact]
    public void WithdrawImpossibleAmountOfMoneyCorrectness()
    {
        const int sourceMoney = 1000;
        const int withdrawAmount = sourceMoney + 1;

        const string userName = "user1";

        IConsole consoleMock = Substitute.For<IConsole>();
        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(withdrawAmount);

        var accountRepository = new AccountRepositoryMock();
        accountRepository.AddAccount(userName, sourceMoney);
        accountRepository.AddAccount("user2");
        accountRepository.AddAccount("user3");

        var currentAccountService = new CurrentAccountService()
        {
            CurrentAccount = accountRepository.FindAccount(userName),
        };

        var currentUserService = new CurrentUserService()
        {
            CurrentUser = new User(userName, UserRole.Client),
        };

        var currentCashMachineService = new CurrentCashMachineService()
        {
            CurrentCashMachine = new CashMachine(1000300),
        };

        var operationRepositoryMock = new OperationRepositoryMock();

        var accountService = new AccountService(
            operationRepositoryMock,
            accountRepository,
            accountRepository,
            currentAccountService);

        var withdrawMoneyScript = new WithdrawMoneyFromAccountScript(
            accountService,
            currentUserService,
            currentCashMachineService,
            consoleMock);

        _ = Assert.Throws<ArgumentOutOfRangeException>(withdrawMoneyScript.Execute);
    }

    [Fact]
    public void CombinationOfDepositAndWithdrawCorrectness()
    {
        const int sourceMoney = 50000;
        const int firstWithdrawAmount = 10000;
        const int secondWithdrawAmount = 5000;
        const int thirdWithdrawAmount = 7;
        const int firstDepositAmount = 700;
        const int secondDepositAmount = 7000;

        const int expectedMoney = sourceMoney - firstWithdrawAmount - secondWithdrawAmount -
            thirdWithdrawAmount + firstDepositAmount + secondDepositAmount;

        const string userName = "user1";

        var accountRepository = new AccountRepositoryMock();
        accountRepository.AddAccount("user2");
        accountRepository.AddAccount(userName, sourceMoney);
        accountRepository.AddAccount("user3");

        var currentAccountService = new CurrentAccountService()
        {
            CurrentAccount = accountRepository.FindAccount(userName),
        };

        var currentUserService = new CurrentUserService()
        {
            CurrentUser = new User(userName, UserRole.Client),
        };

        var currentCashMachineService = new CurrentCashMachineService()
        {
            CurrentCashMachine = new CashMachine(1000300),
        };

        var operationRepositoryMock = new OperationRepositoryMock();

        var accountService = new AccountService(
            operationRepositoryMock,
            accountRepository,
            accountRepository,
            currentAccountService);

        IConsole consoleMock = Substitute.For<IConsole>();

        var withdrawMoneyScript = new WithdrawMoneyFromAccountScript(
            accountService,
            currentUserService,
            currentCashMachineService,
            consoleMock);

        var depositMoneyScript = new DepositMoneyToAccountScript(
            accountService,
            currentUserService,
            currentCashMachineService,
            consoleMock);

        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(firstWithdrawAmount);
        withdrawMoneyScript.Execute();

        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(secondWithdrawAmount);
        withdrawMoneyScript.Execute();

        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(thirdWithdrawAmount);
        withdrawMoneyScript.Execute();

        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(firstDepositAmount);
        depositMoneyScript.Execute();

        consoleMock.Ask<double>(string.Empty).ReturnsForAnyArgs(secondDepositAmount);
        depositMoneyScript.Execute();

        Account? actualAccount = accountRepository.FindAccount(userName);

        Assert.NotNull(actualAccount);
        Assert.Equal(expectedMoney, actualAccount.Money);
    }
}
