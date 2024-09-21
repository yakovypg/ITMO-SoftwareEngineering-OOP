using System;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class PasswordRepository : IPasswordRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public PasswordRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider
            ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public string? FindAdminPassword()
    {
        const string query = "SELECT admin_password FROM admin_passwords;";

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using NpgsqlCommand command = new(query, connection);
        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read()
            ? reader.GetString(0)
            : null;
    }

    public string? FindClientPassword(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        SELECT client_password
        FROM client_passwords
        WHERE user_id IN (SELECT user_id FROM users WHERE user_name = :username);
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read()
            ? reader.GetString(0)
            : null;
    }

    public void AddPassword(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        ArgumentNullException.ThrowIfNull(password, nameof(password));

        const string query = """
        INSERT INTO client_passwords
        (user_id, client_password)
        VALUES ((SELECT user_id FROM users WHERE user_name = :username), :password);
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);
        command.AddParameter("password", password);

        _ = command.ExecuteNonQuery();
    }
}
