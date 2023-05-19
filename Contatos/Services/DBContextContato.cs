using Contatos.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Contatos.Services
{
    public class DBContextContato : IContatosService
    {
        public readonly ContatosContext _contatosContext;
        public DBContextContato(ContatosContext contatosContext)
        {
            this._contatosContext = contatosContext;
        }

        public void Create(int IdCliente, Contato contato)
        {
            var cliente = FindCliente(IdCliente);
            _contatosContext.Contatos.Add(contato);
            _contatosContext.SaveChanges();
        }

        public void Delete(int IdCliente, int IdContato)
        {
            var cliente = FindCliente(IdCliente);
            if (cliente != null)
            {
                var contato = cliente.Contatos.FirstOrDefault(c => c.Id == IdContato);
                if (contato != null)
                {
                    _contatosContext.Contatos.Remove(contato);
                    _contatosContext.SaveChanges();
                }
            }
        }

        public Contato? Find(int IdCliente, int IdContato)
        {
            var cliente = FindCliente(IdCliente);
            if(cliente != null)
            {
                var contato = cliente.Contatos.FirstOrDefault(c=> c.Id== IdContato);
                return contato;
            }
            return null;
        }

        public ICollection<Contato> FindAll(int IdCliente)
        {
            var cliente = FindCliente(IdCliente);
            if (cliente != null)
                return cliente.Contatos.ToList();
            return new List<Contato>();
        }

        public void Update(int IdCliente, int IdContato, Contato contato)
        {
            var cont = Find(IdCliente, IdContato);
            if (cont != null)
            {
                cont.Tipo = contato.Tipo;
                cont.Perfil = contato.Perfil;

                _contatosContext.Contatos.Update(cont);
                _contatosContext.SaveChanges();
            }
        }

        private Cliente? FindCliente (int id)
        {
            return _contatosContext.Clientes.FirstOrDefault(c => c.Id == id);
       
        }
    }
}
