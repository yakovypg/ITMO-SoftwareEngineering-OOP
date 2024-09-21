using System;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Interactions;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Interactions;

public class AccountMoneyInteraction : IAccountMoneyInteraction
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public AccountMoneyInteraction(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider
            ?? throw new ArgumentNullException(nameof(connectionProvider));
    }

    public void DepositMoney(string username, double money)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));

        const string query = """
        UPDATE accounts
        SET money = money + :money
        WHERE account_id IN
            (SELECT account_id FROM accounts WHERE user_id IN
                (SELECT user_id FROM users WHERE user_name = :username));
        """;

        ValueTask<NpgsqlConnection> connectionTask = _postgresConnectionProvider.GetConnectionAsync(default);

        NpgsqlConnection connection = connectionTask.IsCompletedSuccessfully
            ? connectionTask.Result
            : connectionTask.AsTask().GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(query, connection);
        command.AddParameter("username", username);
        command.AddParameter("money", money);

        _ = command.ExecuteNonQuery();
    }

    public void WithdrawMoney(string username, double money)
    {
        DepositMoney(username, -money);
    }
}
