using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUser(string username);
    void AddUser(string username);
}
