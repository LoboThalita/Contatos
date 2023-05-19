using Contatos.Models;

namespace Contatos.Services
{
    public interface IContatosService
    {
        public void Create(int IdCliente, Contato contato);
        public void Update(int IdCliente, int IdContato, Contato contato);
        public void Delete(int IdCliente, int IdContato);
        public Contato? Find(int IdCliente, int IdContato);
        public ICollection<Contato> FindAll(int IdCliente);
    }
}
