using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class UserRepositoryMock : IUserRepository
{
    private readonly List<User> _users;

    public UserRepositoryMock()
    {
        _users = new List<User>();
    }

    public void AddUser(string username, UserRole role)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        if (_users.Any(t => t.Username == username))
            throw new InvalidOperationException("Username already exists");

        _users.Add(new User(username, role));
    }

    public void AddUser(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        AddUser(username, UserRole.Client);
    }

    public User? FindUser(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        return _users.FirstOrDefault(t => t.Username == username);
    }
}
