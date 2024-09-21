using Itmo.ObjectOrientedProgramming.Lab5.Application.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scripts;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

IServiceCollection services = new ServiceCollection()
    .AddApplicationServices()
    .AddInfrastructureDataAccess(t =>
    {
        t.SslMode = "Prefer";
        t.Host = "127.0.0.1";
        t.Port = 5432;
        t.Username = "postgres";
        t.Password = "postgres";
        t.Database = "lab5";
    })
    .AddPresentation();

ServiceProvider provider = services.BuildServiceProvider();

using IServiceScope scope = provider.CreateScope();
scope.UseInfrastructureDataAccess();

ScriptExecutor scriptExecutor = scope.ServiceProvider.GetRequiredService<ScriptExecutor>();

while (true)
{
    _ = scriptExecutor.TryExecute();

    AnsiConsole.WriteLine();
    _ = AnsiConsole.Ask<string>("Pause...");
    AnsiConsole.Clear();
}
