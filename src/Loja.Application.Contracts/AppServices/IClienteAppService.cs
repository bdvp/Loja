namespace Loja.Application.Contracts.AppServices
{
    using Loja.Application.Contracts.Requests;
    using Loja.Application.Contracts.Response;
    using Loja.Application.Contracts.ViewModel;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.ValueObject;
    using System.Threading.Tasks;

    public interface IClienteAppService
    {
        Task<Result> Create(ClienteCreateRequest request);

        Task<Result> Update(ClienteUpdateRequest request);

        Task<Result> Delete(int id);

        Task<Result<Cliente>> Get(int id);

        Task<Result<PaginationResponse<ClienteViewModel>>> GetAll(int pageSize, int pageIndex);

        Task<Result<Cliente>> Get(string cpf);
    }
}
