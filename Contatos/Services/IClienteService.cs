using Contatos.Models;

namespace Contatos.Services
{
    public interface IClienteService
    {
        //Métodos para a entidade Cliente
        public void Create(Cliente model);
        public void Update(Cliente model);
        public void Delete(Cliente model);
        public Cliente? Find(int id);
        public ICollection<Cliente> FindAll();

        //Métodos para a entidade Contato
        public void Create(int IdCliente, Contato contato);
        public void Update(int IdCliente, int IdContato, Contato contato);
        public void Delete(int IdContato);
        public Contato? Find(int IdCliente, int IdContato);
        public ICollection<Contato> FindAll(int IdCliente);
    }
}
