using System;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

public class User
{
    public User(string username, UserRole role)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Role = role;
    }

    public string Username { get; }
    public UserRole Role { get; }
}
