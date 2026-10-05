using Npgsql;
using System;
using System.Runtime.Remoting.Contexts;

namespace ProjectBlackout.Core.Sql
{
    [Synchronization]
    public class SqlConnection
    {
        private static SqlConnection sql = new SqlConnection();
        protected NpgsqlConnectionStringBuilder connBuilder;

        static SqlConnection()
        {

        }

        public SqlConnection()
        {
            connBuilder = new NpgsqlConnectionStringBuilder
            {
                Database = Config.dbName,
                Host = Config.dbHost,
                Username = Config.dbUser,
                Password = Config.dbPass,
                Port = Config.dbPort
            };
        }

        public static SqlConnection getInstance()
        {
            return sql;
        }

        public static bool CheckConnection()
        {
            try
            {
                using (NpgsqlConnection connection = getInstance().conn())
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT 1";
                        command.ExecuteScalar();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.error("Database startup check failed for " + Config.dbHost + ":" +
                    Config.dbPort + "/" + Config.dbName + ". " + ex.Message);
                Logger.error("Check Config/Database.ini in the server's working directory. " +
                    "Ensure PostgreSQL is running and listening on the configured host and port, " +
                    "and that the database and login are valid. Server startup stopped.");
                return false;
            }
        }

        public NpgsqlConnection conn()
        {
            return new NpgsqlConnection(connBuilder.ConnectionString);
        }
    }
}