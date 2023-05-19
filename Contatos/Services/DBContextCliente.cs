using Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Services
{
    public class DBContextCliente : IClienteService
    {
        private readonly ContatosContext _contatosContext;

        public DBContextCliente(ContatosContext contatosContext)
        {
            _contatosContext = contatosContext;
        }

        public void Create(Cliente model)
        {
            _contatosContext.Clientes.Add(model);
            _contatosContext.SaveChanges();
        }

        public void Delete(Cliente model)
        {
            var contatos = _contatosContext.Contatos.Where(contato => contato.IdCliente == model.Id);
            _contatosContext.Contatos.RemoveRange(contatos);
            _contatosContext.Clientes.Remove(model);
            _contatosContext.SaveChanges();
        }

        public Cliente? Find(int id)
        {
            return _contatosContext.Clientes.Include("Contatos").First(x => x.Id == id);
        }

        public ICollection<Cliente> FindAll()
        {
            return _contatosContext.Clientes.ToList();
        }

        public void Update(Cliente cliente)
        {
            _contatosContext.Clientes.Update(cliente);
            _contatosContext.SaveChanges();
        }
    }
}
