using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Machines;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class CashMachineRepository : ICashMachineRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public CashMachineRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider
            ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public IEnumerable<CashMachine> GetAllCashMachines()
    {
        const string query = "SELECT cash_machine_serial_number FROM cash_machines;";

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using NpgsqlCommand command = new(query, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new CashMachine(reader.GetInt32(0));
        }
    }
}
