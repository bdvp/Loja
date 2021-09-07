namespace Loja.Domain.Clientes.Handlers
{
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Handlers;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation.Results;

    public class ClienteDeleteHandler : IHandler<ClienteDeleteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDeleteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<Result> Handle(ClienteDeleteCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.IsValid())
                {
                    return Task.FromResult(Result.Failed(command.ValidationResult.Errors.ToArray()));
                }

                _clienteRepository.Delete(command.Id);
                return Task.FromResult(Result.Success());
            }
            catch (System.Exception e)
            {
                // TODO : implementar NOTIFICATION para exception
                var msg = $"Ocorreu um erro inesperado ao excluir o cliente.";
                return Task.FromResult(Result.Failed(new ValidationFailure(string.Empty, msg)));
            }
        }
    }
}
