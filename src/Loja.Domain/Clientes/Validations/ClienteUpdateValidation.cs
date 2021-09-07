namespace Loja.Domain.Clientes.Validations
{
    using Loja.Domain.Clientes.Commands;

    public class ClienteUpdateValidation : ClienteValidation<ClienteUpdateCommand>
    {
        public ClienteUpdateValidation()
        {
            ValidateId();
            ValidateNome();
            ValidateEmail();
        }
    }
}
