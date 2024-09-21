using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider
            ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public IEnumerable<Operation> GetAllUserOperations(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        SELECT money, operation_type, cash_machine_serial_number
        FROM operations
        WHERE account_id IN
            (SELECT account_id FROM accounts WHERE user_id IN
                (SELECT user_id FROM users WHERE user_name = :username));
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using NpgsqlCommand command = new(query, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                reader.GetDouble(0),
                reader.GetFieldValue<OperationType>(1),
                reader.GetInt32(2));
        }
    }

    public void AddOperation(string username, OperationType operationType, double money, int cashMachineSerialNumber)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = $"""
        INSERT INTO operations
        (operation_type, money, cash_machine_serial_number, account_id)
        VALUES (:operationType, :money, :cashMachineSerialNumber,
            (SELECT account_id FROM accounts WHERE user_id IN
                (SELECT user_id FROM users WHERE user_name = :username)
            LIMIT 1));
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using NpgsqlCommand command = new(query, connection);
        command.AddParameter("username", username);
        command.AddParameter("money", money);
        command.AddParameter("cashMachineSerialNumber", cashMachineSerialNumber);
        command.AddParameter("operationType", operationType);

        _ = command.ExecuteNonQuery();
    }
}
