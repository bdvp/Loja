namespace Loja.Infra.Data.Context
{
    using Loja.Infra.Data.Contracts;
    using Microsoft.Extensions.Configuration;

    public class QueryConnection : ConnectionFactory, IQueryConnection
    {
        private const string _SqlConnectionConfiguration = "SQLQueryConnection";

        public QueryConnection(IConfiguration configuration) : base(configuration.GetConnectionString(_SqlConnectionConfiguration))
        {
        }
    }
}
