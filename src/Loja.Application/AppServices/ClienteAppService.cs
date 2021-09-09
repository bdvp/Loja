namespace Loja.Application.AppServices
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Application.Contracts.Queries;
    using Loja.Application.Contracts.Requests;
    using Loja.Application.Contracts.Response;
    using Loja.Application.Contracts.ViewModel;
    using Loja.Domain.Clientes.Commands;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.Repositories;
    using Loja.Domain.Core.ValueObject;
    using Loja.Infra.CrossCutting.Bus;
    using System.Threading.Tasks;

    public class ClienteAppService : IClienteAppService
    {
        private readonly IBusMediator _bus;
        private readonly IClienteRepository _repository;

        public ClienteAppService(
            IBusMediator bus, 
            IClienteRepository repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task<Result> Create(ClienteCreateRequest request)
        {
            try
            {
                var command = new ClienteCreateCommand(request.Cpf, request.Nome, request.Email);
                return await _bus.SendCommand(command);
            }
            catch (System.Exception e)
            {
                // TODO: implementar log/telemetria da exception
                var msg = "Erro inesperado ao criar cliente.";
                return await Task.FromResult(Result.Failed(msg));
            }
        }

        public async Task<Result> Update(ClienteUpdateRequest request)
        {
            try
            {
                var command = new ClienteUpdateCommand(request.Id, request.Nome, request.Email);
                return await _bus.SendCommand(command);
            }
            catch (System.Exception e)
            {
                var msg = "Erro inesperado ao atualizar cliente.";
                return await Task.FromResult(Result.Failed(msg));
            }
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                var command = new ClienteDeleteCommand(id);
                return await _bus.SendCommand(command);
            }
            catch (System.Exception e)
            {
                var msg = "Erro inesperado ao excluir cliente.";
                return await Task.FromResult(Result.Failed(msg));
            }
        }

        public async Task<Result<Cliente>> Get(int id)
        {
            try
            {
                var cliente = _repository.Get(id);
                return await Task.FromResult(Result.Success(cliente.Result));
            }
            catch (System.Exception e)
            {
                var msg = $"Erro inesperado ao buscar cliente: {id}.";
                return await Task.FromResult(Result.Failed<Cliente>(msg));
            }
        }

        public async Task<Result<PaginationResponse<ClienteViewModel>>> GetAll(int pageSize, int pageIndex)
        {
            try
            {
                var query = new ClienteGetAllQuery(pageSize, pageIndex);
                var result = await _bus.SendQuery(query);

                return await Task.FromResult(Result.Success(result));
            }
            catch (System.Exception e)
            {
                var msg = "Erro inesperado ao retorna lista de clientes";
                return await Task.FromResult(Result.Failed<PaginationResponse<ClienteViewModel>>(msg));
            }
        }

        public async Task<Result<Cliente>> Get(string cpf)
        {
            try
            {
                var query = new ClienteGetCpfQuery(cpf);
                var result = await _bus.SendQuery(query);

                return await Task.FromResult(Result.Success(result));
            }
            catch (System.Exception e)
            {
                var msg = $"Erro inesperado ao buscar cliente: {cpf}.";
                return await Task.FromResult(Result.Failed<Cliente>(msg));
            }
        }
    }
}
