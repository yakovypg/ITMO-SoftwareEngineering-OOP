using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordRepository _passwordRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICurrentAccountService _currentAccountService;

    public UserService(
        IUserRepository userRepository,
        IPasswordRepository passwordRepository,
        IAccountRepository accountRepository,
        ICurrentUserService currentUserService,
        ICurrentAccountService currentAccountService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordRepository = passwordRepository ?? throw new ArgumentNullException(nameof(passwordRepository));
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        _currentAccountService = currentAccountService ?? throw new ArgumentNullException(nameof(currentAccountService));
    }

    public LoginResult Login(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        User? foundUser = _userRepository.FindUser(username);

        if (foundUser is null)
        {
            _currentUserService.CurrentUser = null;
            return LoginResult.UserNotFound;
        }

        string? foundUserPassword = foundUser.Role == UserRole.Admin
            ? _passwordRepository.FindAdminPassword()
            : _passwordRepository.FindClientPassword(username);

        if (foundUserPassword != password)
        {
            _currentUserService.CurrentUser = null;
            return LoginResult.IncorrectPassword;
        }

        Account? foundUserAccount = _accountRepository.FindAccount(username);

        _currentUserService.CurrentUser = foundUser;
        _currentAccountService.CurrentAccount = foundUserAccount;

        return LoginResult.Success;
    }

    public RegisterResult Register(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        User? foundUser = _userRepository.FindUser(username);

        if (foundUser is not null)
            return RegisterResult.UsernameAlreadyExists;

        _userRepository.AddUser(username);
        _passwordRepository.AddPassword(username, password);
        _accountRepository.AddAccount(username);

        return RegisterResult.Success;
    }
}
