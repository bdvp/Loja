namespace Loja.Infra.Data.Clientes
{
    using Dapper;
    using Loja.Application.Contracts.AppServices;
    using Loja.Application.Contracts.Queries;
    using Loja.Application.Contracts.Response;
    using Loja.Application.Contracts.ViewModel;
    using Loja.Domain.Core.Models;
    using Loja.Infra.Data.Contracts;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ClienteQueryRepository : 
        IQueryHandler<ClienteGetAllQuery, PaginationResponse<ClienteViewModel>>,
        IQueryHandler<ClienteGetCpfQuery, Cliente>
    {
        private readonly IQueryConnection _queryConnection;

        public ClienteQueryRepository(IQueryConnection queryConnection)
        {
            _queryConnection = queryConnection;
        }

        public async Task<PaginationResponse<ClienteViewModel>> Handle(ClienteGetAllQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }

            using (var conn = _queryConnection.Create())
            {
                var skip = (request.PageIndex - 1) * request.PageSize;
                var take = request.PageSize;

                var query = @"SELECT Nome, Cpf, Email FROM Cliente ORDER BY Nome OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

                var cliente = await conn.QueryAsync<ClienteViewModel>(query, new { Skip = skip, Take = take });
                return new PaginationResponse<ClienteViewModel>(cliente, request.PageIndex, request.PageSize);
            }
        }

        public async Task<Cliente> Handle(ClienteGetCpfQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (var conn = _queryConnection.Create())
            {
                var query = @"SELECT Id, Nome, Cpf, Email FROM Cliente WHERE Cpf = @Cpf;";
                return await conn.QueryFirstOrDefaultAsync<Cliente>(query, new { request.Cpf });
            }
        }
    }
}
