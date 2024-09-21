namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;

public interface IPasswordRepository
{
    string? FindAdminPassword();
    string? FindClientPassword(string username);
    void AddPassword(string username, string password);
}
