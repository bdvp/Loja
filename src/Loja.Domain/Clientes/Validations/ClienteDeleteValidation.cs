namespace Loja.Domain.Clientes.Validations
{
    using Loja.Domain.Clientes.Commands;

    public class ClienteDeleteValidation : ClienteValidation<ClienteDeleteCommand>
    {
        public ClienteDeleteValidation()
        {
            ValidateId();
        }
    }
}
