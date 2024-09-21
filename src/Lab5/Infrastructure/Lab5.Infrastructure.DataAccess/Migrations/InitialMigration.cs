using System;
using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial migration")]
public class InitialMigration : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
        CREATE TYPE user_role AS ENUM
        (
            'client',
            'admin'
        );

        CREATE TYPE operation_type AS ENUM
        (
            'deposit',
            'withdraw'
        );

        CREATE TABLE users
        (
            user_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            user_name TEXT NOT NULL UNIQUE,
            user_role user_role DEFAULT 'client' NOT NULL
        );

        CREATE TABLE client_passwords
        (
            client_password_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            user_id BIGINT NOT NULL UNIQUE REFERENCES users(user_id),
            client_password TEXT NOT NULL
        );

        CREATE TABLE admin_passwords
        (
            admin_password_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            admin_password TEXT NOT NULL
        );
        
        CREATE TABLE cash_machines
        (
            cash_machine_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            cash_machine_serial_number INT NOT NULL UNIQUE
        );

        CREATE TABLE accounts
        (
            account_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            user_id BIGINT NOT NULL UNIQUE REFERENCES users(user_id),
            money DOUBLE PRECISION CHECK (money >= 0)
        );

        CREATE TABLE operations
        (
            operation_id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
            account_id BIGINT NOT NULL REFERENCES accounts(account_id),
            operation_type operation_type NOT NULL,
            money DOUBLE PRECISION NOT NULL,
            cash_machine_serial_number BIGINT NOT NULL REFERENCES cash_machines(cash_machine_serial_number)
        );

        INSERT INTO users (user_name, user_role) VALUES ('admin', 'admin');
        INSERT INTO admin_passwords (admin_password) VALUES ('admin');

        INSERT INTO cash_machines (cash_machine_serial_number) VALUES (1000200);
        INSERT INTO cash_machines (cash_machine_serial_number) VALUES (3000400);
        INSERT INTO cash_machines (cash_machine_serial_number) VALUES (5000600);
        """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
        DROP TABLE users;
        DROP TABLE client_passwords;
        DROP TABLE admin_passwords;
        DROP TABLE cash_machines;
        DROP TABLE accounts;
        DROP TABLE operations;

        DROP TYPE user_role;
        DROP TYPE operation_type;
        """;
    }
}
