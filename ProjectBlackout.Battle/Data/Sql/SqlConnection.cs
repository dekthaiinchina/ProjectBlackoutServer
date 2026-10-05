using Npgsql;
using ProjectBlackout.Battle.Data.Configs;
using System.Runtime.Remoting.Contexts;

namespace ProjectBlackout.Battle.Data.Sql
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
                Database = BattleConfig.dbName,
                Host = BattleConfig.dbHost,
                Username = BattleConfig.dbUser,
                Password = BattleConfig.dbPass,
                Port = BattleConfig.dbPort
            };
        }

        public static SqlConnection getInstance()
        {
            return sql;
        }

        public NpgsqlConnection conn()
        {
            return new NpgsqlConnection(connBuilder.ConnectionString);
        }
    }
}