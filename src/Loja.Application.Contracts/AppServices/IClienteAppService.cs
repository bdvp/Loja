namespace Loja.Application.Contracts.AppServices
{
    using Loja.Application.Contracts.Requests;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.ValueObject;
    using System.Threading.Tasks;

    public interface IClienteAppService
    {
        Task<Result> Create(ClienteCreateRequest request);

        Task<Result> Update(ClienteUpdateRequest request);

        Task<Result> Delete(int id);

        Task<Result<Cliente>> Get(int id);
    }
}
