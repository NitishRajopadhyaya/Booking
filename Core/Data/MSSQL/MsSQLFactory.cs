using Core.Enum;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Core.Data.MSSQL
{
    public class MsSQLFactory : IDatabaseFactory
    {
        public IDbConnection Db { get; set; }
        public QueryBuilder QueryBuilder { get; }
        public Dialect Dialect => Dialect.SQLServer;

        private readonly string _connectionString;

        public IDbConnection GetConnection()
        {
            Db = new SqlConnection(_connectionString);
            return Db;
        }
        public MsSQLFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            Db = new SqlConnection(_connectionString);
            QueryBuilder = new MySqlQueryBuilder(new MsSQLTemplate());
        }

        public void Dispose()
        {
            if (Db.State == ConnectionState.Open)
                Db.Close();
            Db.Close();
        }
    }

}