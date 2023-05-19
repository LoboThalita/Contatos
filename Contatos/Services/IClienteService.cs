using Contatos.Models;

namespace Contatos.Services
{
    public interface IClienteService
    {
        public void Create(Cliente model);
        public void Update(Cliente model);
        public void Delete(Cliente model);
        public Cliente? Find(int id);
        public ICollection<Cliente> FindAll();
    }
}
