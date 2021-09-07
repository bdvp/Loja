namespace Loja.Domain.Clientes.Validations
{
    using Loja.Domain.Clientes.Commands;

    public class ClienteCreateValidation : ClienteValidation<ClienteCreateCommand>
    {
        public ClienteCreateValidation()
        {
            ValidateCpf();
            ValidateNome();
            ValidateEmail();
        }
    }
}
