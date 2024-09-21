using System;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider
            ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public User? FindUser(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        SELECT user_name, user_role
        FROM users
        WHERE user_name = :username;
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        return new User(
            reader.GetString(0),
            reader.GetFieldValue<UserRole>(1));
    }

    public void AddUser(string username)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        INSERT INTO users
        (user_name, user_role)
        VALUES (:username, :userRole);
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);
        command.AddParameter("userRole", UserRole.Client);

        _ = command.ExecuteNonQuery();
    }
}
