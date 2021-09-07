namespace Loja.Domain.Core.Repositories
{
    using Loja.Domain.Core.Models;
    using System.Threading.Tasks;

    public interface IClienteRepository
    {
        Cliente Get(int id);

        void Add(Cliente entity);

        void Update(int id, string nome, string email);

        void Delete(int id);

        bool Exist(int id);

        bool Exist(string cpf);
    }
}
