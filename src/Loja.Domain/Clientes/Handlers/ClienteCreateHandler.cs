namespace Loja.Domain.Clientes.Handlers
{
    using FluentValidation.Results;
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Handlers;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ClienteCreateHandler : IHandler<ClienteCreateCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCreateHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Result> Handle(ClienteCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.IsValid())
                {
                    return await Task.FromResult(Result.Failed(command.ValidationResult.Errors.ToArray()));
                }

                if (_clienteRepository.Exist(command.Cpf))
                {
                    var msg = $"Já existe um cadastro para o CPF informado.";
                    return await Task.FromResult(Result.Failed(new ValidationFailure(string.Empty, msg)));
                }

                var cliente = new Cliente() { Cpf = command.Cpf, Nome = command.Nome, Email = command.Email };
                _clienteRepository.Add(cliente);

                return await Task.FromResult(Result.Success());
            }
            catch (Exception e)
            {
                // TODO : implementar NOTIFICATION para exception
                var msg = $"Ocorreu um erro inesperado ao cadastrar o cliente.";
                return await Task.FromResult(Result.Failed(new ValidationFailure(string.Empty, msg)));
            }
        }
    }
}
