using System;
using Itmo.Dev.Platform.Postgres.Plugins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.DataSourcePlugins;

public class EnumMappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        _ = builder.MapEnum<UserRole>();
        _ = builder.MapEnum<OperationType>();
    }
}
