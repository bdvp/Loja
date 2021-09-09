namespace Loja.Infra.Data.Context
{
    using System.Data;
    using System.Data.SqlClient;

    public abstract class ConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
