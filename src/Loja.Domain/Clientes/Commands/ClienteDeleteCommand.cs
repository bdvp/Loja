namespace Loja.Domain.Clientes.Commands
{
    using Loja.Domain.Clientes.Validations;

    public class ClienteDeleteCommand : ClienteCommand
    {
        public ClienteDeleteCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return Validate(new ClienteDeleteValidation().Validate(this));
        }
    }
}
