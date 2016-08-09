using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using MPD.Interviews.Interfaces.Repositories;

namespace MPD.Interviews.Repository
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly string _connectionString;

        public ConnectionProvider()
        {
            var path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            _connectionString = $"Data source={Path.Combine(path, "interview.db")}";

        }

        SQLiteConnection IConnectionProvider.GetOpenConnection()
        {
            return new SQLiteConnection(_connectionString).OpenAndReturn();
        }
    }
}