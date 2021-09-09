namespace Loja.Infra.Data.Clientes
{
    using Dapper;
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.Repositories;
    using Loja.Infra.Data.Contracts;
    using System;
    using System.Threading.Tasks;

    public class ClienteRepository : IClienteRepository
    {
        private readonly ICommandConnection _commandConnection;

        public ClienteRepository(ICommandConnection commandConnection)
        {
            _commandConnection = commandConnection;
        }

        public async Task<int> Add(Cliente entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (var conn = _commandConnection.Create())
            {
                var command = @"INSERT INTO Cliente (Cpf, Nome, Email) VALUES (@Cpf, @Nome, @Email);";
                return await conn.ExecuteAsync(command, entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var conn = _commandConnection.Create())
            {
                var command = @"DELETE Cliente WHERE Id = @Id;";
                return await conn.ExecuteAsync(command, new { id });
            }
        }

        public async Task<int> Update(int id, string nome, string email)
        {
            using (var conn = _commandConnection.Create())
            {
                var command = @"UPDATE Cliente SET Nome = @Nome, Email = @Email WHERE Id = @Id;";
                return await conn.ExecuteAsync(command, new { Nome = nome, Email = email, Id = id });
            }
        }

        public async Task<bool> Exist(int id)
        {
            using (var conn = _commandConnection.Create())
            {
                var query = @"SELECT Count(1) FROM Cliente WHERE Id = @Id;";
                return await conn.QueryFirstOrDefaultAsync<bool>(query, new { id }) ;
            }
        }

        public async Task<bool> Exist(string cpf)
        {
            using (var conn = _commandConnection.Create())
            {
                var query = @"SELECT Count(1) FROM Cliente WHERE Cpf = @Cpf;";
                return await conn.QueryFirstOrDefaultAsync<bool>(query, new { cpf });
            }
        }

        public async Task<Cliente> Get(int id)
        {
            using (var conn = _commandConnection.Create())
            {
                var query = @"SELECT Id, Nome, Cpf, Email FROM Cliente WHERE Id = @Id;";
                return await conn.QueryFirstOrDefaultAsync<Cliente>(query, new { id });
            }
        }
    }
}
