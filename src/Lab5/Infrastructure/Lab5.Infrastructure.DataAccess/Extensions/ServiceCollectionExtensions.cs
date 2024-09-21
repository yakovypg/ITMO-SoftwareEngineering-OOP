using System;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Interactions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.DataSourcePlugins;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Interactions;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection services,
        Action<PostgresConnectionConfiguration> postgresConfig)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(postgresConfig, nameof(postgresConfig));

        _ = services.AddPlatformPostgres(t => t.Configure(postgresConfig));
        _ = services.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        _ = services.AddScoped<IAccountMoneyInteraction, AccountMoneyInteraction>();
        _ = services.AddScoped<IAccountRepository, AccountRepository>();
        _ = services.AddScoped<ICashMachineRepository, CashMachineRepository>();
        _ = services.AddScoped<IOperationRepository, OperationRepository>();
        _ = services.AddScoped<IPasswordRepository, PasswordRepository>();
        _ = services.AddScoped<IUserRepository, UserRepository>();

        _ = services.AddSingleton<IDataSourcePlugin, EnumMappingPlugin>();

        return services;
    }
}
