using System;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Accounts;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider
            ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public Account? FindAccount(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        SELECT money
        FROM accounts
        WHERE user_id = (SELECT user_id FROM USERS WHERE user_name = :username);
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read()
            ? new Account(reader.GetDouble(0))
            : null;
    }

    public void AddAccount(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        INSERT INTO accounts
        (user_id, money)
        VALUES ((SELECT user_id FROM users WHERE user_name = :username), 0.0);
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);

        _ = command.ExecuteNonQuery();
    }
}
