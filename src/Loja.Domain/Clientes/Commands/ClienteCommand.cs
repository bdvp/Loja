namespace Loja.Domain.Clientes.Commands
{
    using Loja.Domain.Core.Commands;

    public abstract class ClienteCommand : Command
    {
        public int Id { get; protected set; }

        public string Cpf { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }
    }
}
