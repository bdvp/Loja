namespace Loja.Domain.Clientes.Commands
{
    using Loja.Domain.Clientes.Validations;
    using Loja.Domain.Core.Extension;

    public class ClienteCreateCommand : ClienteCommand
    {
        public ClienteCreateCommand(string cpf, string nome, string email)
        {
            Cpf = cpf.OnlyNumbers();
            Nome = nome;
            Email = email;
        }

        public override bool IsValid()
        {
            return Validate(new ClienteCreateValidation().Validate(this));
        }
    }
}
