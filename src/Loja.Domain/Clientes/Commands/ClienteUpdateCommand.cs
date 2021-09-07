namespace Loja.Domain.Clientes.Commands
{
    using Loja.Domain.Clientes.Validations;

    public class ClienteUpdateCommand :  ClienteCommand
    {
        public ClienteUpdateCommand(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public override bool IsValid()
        {
            return Validate(new ClienteUpdateValidation().Validate(this));
        }
    }
}
