using System;
using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;

public static class ServiceScopeExtensions
{
    public static void UseInfrastructureDataAccess(this IServiceScope serviceScope)
    {
        ArgumentNullException.ThrowIfNull(serviceScope, nameof(serviceScope));

        serviceScope.UsePlatformMigrationsAsync(default)
            .GetAwaiter()
            .GetResult();
    }
}
