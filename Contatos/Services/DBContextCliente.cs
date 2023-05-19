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

        public void Create(int IdCliente, Contato contato)
        {
            var cliente = Find(IdCliente);
            cliente?.Contatos.Add(contato);
            _contatosContext.SaveChanges();
        }

        public void Delete(Cliente model)
        {
            var contatos = _contatosContext.Contatos.Where(contato => contato.IdCliente == model.Id);
            _contatosContext.Contatos.RemoveRange(contatos);
            _contatosContext.Clientes.Remove(model);
            _contatosContext.SaveChanges();
        }

        public void Delete(int IdContato)
        {
                var contato = _contatosContext.Contatos.FirstOrDefault(c => c.Id == IdContato);
                if (contato is not null)
                {
                    _contatosContext.Contatos.Remove(contato);
                    _contatosContext.SaveChanges();
                }
        }

        public Cliente? Find(int id)
        {
            return _contatosContext.Clientes.Include(p => p.Contatos).FirstOrDefault(x => x.Id == id);
        }

        public Contato? Find(int IdCliente, int IdContato)
        {
            var cliente = Find(IdCliente);
            if (cliente is not null)
            {
                var contato = cliente.Contatos.FirstOrDefault(c => c.Id == IdContato);
                return contato;
            }
            return null;
        }

        public ICollection<Cliente> FindAll()
        {
            return _contatosContext.Clientes.ToList();
        }

        public ICollection<Contato> FindAll(int IdCliente)
        {
            var cliente = Find(IdCliente);
            if (cliente is not null)
                return cliente.Contatos.ToList();
            return new List<Contato>();
        }

        public void Update(Cliente cliente)
        {
            _contatosContext.Clientes.Update(cliente);
            _contatosContext.SaveChanges();
        }

        public void Update(int IdCliente, int IdContato, Contato contato)
        {
            var cont = Find(IdCliente, IdContato);
            if (cont is not null)
            {
                cont.Tipo = contato.Tipo;
                cont.Perfil = contato.Perfil;

                _contatosContext.Contatos.Update(cont);
                _contatosContext.SaveChanges();
            }
        }
    }
}
