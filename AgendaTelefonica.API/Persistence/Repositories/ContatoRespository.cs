using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.API.Persistence.Repositories
{
    public class ContatoRespository : IContatoRepository
    {
        private readonly AgendaContext _context;
        public ContatoRespository(AgendaContext context) => _context = context;

        public void Adicionar(Contato user)
        {
            _context.Contatos.Add(user);
            _context.SaveChanges();
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            _context.SaveChanges();
        }

        public void Alterar(Contato user)
        {
            _context.Contatos.Update(user);
            _context.SaveChanges();
        }

        public void AtualizarTelefone(Telefone telefone)
        {
            _context.Telefones.Update(telefone);
            _context.SaveChanges();
        }

        public void Deletar(Contato user)
        {
            _context.Contatos.Remove(user);
            _context.SaveChanges();
        }

        public List<Contato> Obter()
        {
            return _context.Contatos.Include(t => t.Telefone).AsNoTracking().ToList();
        }

        public Contato ObterPorId(int id)
        {
            return _context.Contatos.Include(t => t.Telefone).SingleOrDefault(x => x.Id == id);
        }
    }
}