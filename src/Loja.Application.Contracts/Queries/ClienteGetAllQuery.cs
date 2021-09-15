namespace Loja.Application.Contracts.Queries
{
    using Loja.Application.Contracts.AppServices;
    using Loja.Application.Contracts.Response;
    using Loja.Application.Contracts.ViewModel;

    public class ClienteGetAllQuery : PaginationQuery, IQuery<PaginationResponse<ClienteViewModel>>
    {
        public ClienteGetAllQuery(int pageSize, int pageIndex) : base(pageSize, pageIndex)
        {
        }
    }
}
