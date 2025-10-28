using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace CaroServer
{
    public static class Database
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "server.db");
        private static readonly string ConnStr = $"Data Source={DbPath};";

        public static SqliteConnection GetConnection()
        {
            var c = new SqliteConnection(ConnStr);
            c.Open();
            return c;
        }

        public static void Initialize()
        {
            if (!File.Exists(DbPath)) File.Create(DbPath).Dispose();

            using var conn = GetConnection();
            const string sql = @"
                CREATE TABLE IF NOT EXISTS Users(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username     TEXT UNIQUE NOT NULL,
                    PasswordHash TEXT NOT NULL,
                    Email        TEXT,
                    FullName     TEXT,
                    Age          TEXT,
                    Address      TEXT,
                    Phone        TEXT
                );";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
