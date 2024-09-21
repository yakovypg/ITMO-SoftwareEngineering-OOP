using System;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Machines;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        _ = services.AddScoped<IAccountService, AccountService>();
        _ = services.AddScoped<ICurrentAccountService, CurrentAccountService>();
        _ = services.AddScoped<ICashMachineService, CashMachineService>();
        _ = services.AddScoped<ICurrentCashMachineService, CurrentCashMachineService>();
        _ = services.AddScoped<IUserService, UserService>();
        _ = services.AddScoped<ICurrentUserService, CurrentUserService>();
        _ = services.AddScoped<IOperationService, OperationService>();

        return services;
    }
}
