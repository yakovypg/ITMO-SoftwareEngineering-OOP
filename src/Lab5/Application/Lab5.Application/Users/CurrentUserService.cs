using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Users;

public class CurrentUserService : ICurrentUserService
{
    public User? CurrentUser { get; set; }
}
