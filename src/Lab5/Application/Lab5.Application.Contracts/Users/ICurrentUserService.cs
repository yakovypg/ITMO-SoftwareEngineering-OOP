using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;

public interface ICurrentUserService
{
    User? CurrentUser { get; set; }
}
