namespace Loja.Application.AppServices
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Application.Contracts.Requests;
    using Loja.Application.Contracts.ViewModel;
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using Loja.Infra.CrossCutting.Bus;
    using System.Threading.Tasks;

    public class ClienteAppService : IClienteAppService
    {
        private readonly IBusHandler _bus;
        private readonly IClienteRepository _repository;

        public ClienteAppService(
            IBusHandler bus, 
            IClienteRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task<Result> Create(ClienteCreateRequest request)
        {
            var command = new ClienteCreateCommand(request.Cpf, request.Nome, request.Email);
            return await _bus.SendCommand(command);
        }

        public async Task<Result> Update(ClienteUpdateRequest request)
        {
            var command = new ClienteUpdateCommand(request.Id, request.Nome, request.Email);
            return await _bus.SendCommand(command);
        }

        public async Task<Result> Delete(int id)
        {
            var command = new ClienteDeleteCommand(id);
            return await _bus.SendCommand(command);
        }

        public async Task<Result<Cliente>> Get(int id)
        {
            var cliente = _repository.Get(id); // TODO: implementar BusQueryHandler p/ consultas
            return await Task.FromResult(Result.Success(cliente));
        }
    }
}
