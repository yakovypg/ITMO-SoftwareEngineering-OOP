using System;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        _ = services.AddScoped<ScriptExecutor>();

        _ = services.AddScoped<IScriptProvider, AdminLoginScriptProvider>();
        _ = services.AddScoped<IScriptProvider, ClientLoginScriptProvider>();
        _ = services.AddScoped<IScriptProvider, CreateAccountScriptProvider>();
        _ = services.AddScoped<IScriptProvider, SelectCashMachineScriptProvider>();
        _ = services.AddScoped<IScriptProvider, ShowBalanceScriptProvider>();
        _ = services.AddScoped<IScriptProvider, ShowOperationHistoryScriptProvider>();
        _ = services.AddScoped<IScriptProvider, DepositMoneyToAccountScriptProvider>();
        _ = services.AddScoped<IScriptProvider, WithdrawMoneyFromAccountScriptProvider>();
        _ = services.AddScoped<IScriptProvider, ExitScriptProvider>();

        return services;
    }
}
