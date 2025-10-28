using System;
using Microsoft.Data.Sqlite;

namespace CaroServer
{
    public static class UserRepo
    {
        public static bool Register(User user)
        {
            using var conn = Database.GetConnection();
            const string sql = @"
                INSERT INTO Users (Username, PasswordHash, Email, FullName, Age, Address, Phone)
                VALUES (@u, @p, @e, @f, @a, @ad, @ph);";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", user.Username);
            cmd.Parameters.AddWithValue("@p", user.PasswordHash);
            cmd.Parameters.AddWithValue("@e", user.Email);
            cmd.Parameters.AddWithValue("@f", user.FullName);
            cmd.Parameters.AddWithValue("@a", user.Age);
            cmd.Parameters.AddWithValue("@ad", user.Address);
            cmd.Parameters.AddWithValue("@ph", user.Phone);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static User? GetUser(string username)
        {
            using var conn = Database.GetConnection();
            const string sql = "SELECT * FROM Users WHERE lower(Username)=lower(@u) LIMIT 1;";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", username);

            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return null;

            return new User
            {
                Id = Convert.ToInt32(rdr["Id"]),
                Username = rdr["Username"]?.ToString() ?? "",
                PasswordHash = rdr["PasswordHash"]?.ToString() ?? "",
                Email = rdr["Email"]?.ToString() ?? "",
                FullName = rdr["FullName"]?.ToString() ?? "",
                Age = rdr["Age"]?.ToString() ?? "",
                Address = rdr["Address"]?.ToString() ?? "",
                Phone = rdr["Phone"]?.ToString() ?? ""
            };
        }
    }
}
