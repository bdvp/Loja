namespace Loja.Domain.Clientes.Handlers
{
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Handlers;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using System.Threading;
    using System.Threading.Tasks;
    using Loja.Domain.Core.Resources;

    public class ClienteDeleteHandler : IHandler<ClienteDeleteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDeleteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Result> Handle(ClienteDeleteCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.IsValid())
                {
                    return await Task.FromResult(Result.Failed(command.ValidationResult.Errors.ToArray()));
                }

                await _clienteRepository.Delete(command.Id);
                return await Task.FromResult(Result.Success());
            }
            catch (System.Exception e)
            {
                // TODO : implementar NOTIFICATION para exception
                var msg = string.Format(ClienteResource.ExceptionUnexpectedly, "atualizar");
                return await Task.FromResult(Result.Failed(msg));
            }
        }
    }
}
