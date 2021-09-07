namespace Loja.Domain.Clientes.Handlers
{
    using FluentValidation.Results;
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Handlers;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ClienteUpdateHandler : IHandler<ClienteUpdateCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUpdateHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Result> Handle(ClienteUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.IsValid())
                {
                    return await Task.FromResult(Result.Failed(command.ValidationResult.Errors.ToArray()));
                }

                if (!_clienteRepository.Exist(command.Id))
                {
                    var msg = $"Cliente não encontrado.";
                    return await Task.FromResult(Result.Failed(new ValidationFailure(string.Empty, msg)));
                }

                _clienteRepository.Update(command.Id, command.Nome, command.Email);

                return await Task.FromResult(Result.Success());
            }
            catch (Exception e)
            {
                // TODO : implementar NOTIFICATION para exception
                var msg = $"Ocorreu um erro inesperado ao atualizar o cliente.";
                return await Task.FromResult(Result.Failed(new ValidationFailure(string.Empty, msg)));
            }
        }
    }
}
