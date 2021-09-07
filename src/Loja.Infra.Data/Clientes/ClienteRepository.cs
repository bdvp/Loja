namespace Loja.Infra.Data.Clientes
{
    using Loja.Domain.Core.Models;
    using Loja.Domain.Core.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClienteRepository : IClienteRepository
    {
        private readonly static Dictionary<int, Cliente> _clientes = new Dictionary<int, Cliente>();
        private static int id;

        public void Add(Cliente entity)
        {
            entity.Id = ++id;
            _clientes.Add(entity.Id, entity);
        }

        public void Delete(int id)
        {
            _clientes.Remove(id);
        }

        public void Update(int id, string nome, string email)
        {
            _clientes[id].Nome = nome;
            _clientes[id].Email = email;
        }

        public bool Exist(int id)
        {
            return _clientes.ContainsKey(id);
        }

        public bool Exist(string cpf)
        {
            return _clientes.FirstOrDefault(c => c.Value.Cpf == cpf).Key > 0;
        }

        public Cliente Get(int id)
        {
            return _clientes.GetValueOrDefault(id);
        }
    }
}
