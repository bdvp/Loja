namespace Loja.Infra.Data.Context
{
    using Loja.Infra.Data.Contracts;
    using Microsoft.Extensions.Configuration;

    public class CommandConnection : ConnectionFactory, ICommandConnection
    {
        private const string _SqlConnectionConfiguration = "SQLCommandConnection";

        public CommandConnection(IConfiguration configuration) : base(configuration.GetConnectionString(_SqlConnectionConfiguration))
        {
        }
    }
}
