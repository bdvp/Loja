namespace Loja.Domain.Core.Repositories
{
    using Loja.Domain.Core.Models;
    using System.Threading.Tasks;

    public interface IClienteRepository
    {
        Task<Cliente> Get(int id);

        Task<int> Add(Cliente entity);

        Task<int> Update(int id, string nome, string email);

        Task<int> Delete(int id);

        Task<bool> Exist(int id);

        Task<bool> Exist(string cpf);
    }
}
