using Dapper;
using Microsoft.Data.Sqlite;
using System.Configuration;
using System.Data;

namespace CodingTracker;

internal class DatabaseManager
{
    private readonly string? _connectionString;

    internal DatabaseManager()
    {
        _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }

    internal void EnsureDatabaseExists()
    {
        try
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("ConnectionString is missing from the config file");

            using IDbConnection connection = new SqliteConnection(_connectionString);
            connection.Open();

            const string createTable = @"
            CREATE TABLE IF NOT EXISTS coding_tracker (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                start_time TEXT NOT NULL,
                end_time TEXT NOT NULL,
                duration TEXT NOT NULL
            );";

            connection.Execute(createTable);

            Console.WriteLine("Database and table are ready.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error establishing connection with database: {ex.Message}");
        }
    }
}
