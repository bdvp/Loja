namespace Loja.Application.Contracts.Queries
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Domain.Core.Extension;
    using Loja.Domain.Core.Models;

    public class ClienteGetCpfQuery : IQuery<Cliente>
    {
        public ClienteGetCpfQuery(string cpf)
        {
            Cpf = cpf.OnlyNumbers();
        }

        public string Cpf { get; set; }
    }
}
