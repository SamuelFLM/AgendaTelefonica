using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.API.Entities;

namespace AgendaTelefonica.API.Persistence.Repositories
{
    public interface IContatoRepository
    {
        List<Contato> Obter();
        Contato ObterPorId(int id);
        void Adicionar(Contato user);
        void Alterar(Contato user);
        void Deletar(Contato user);
        void AdicionarTelefone(Telefone telefone);
        void AtualizarTelefone(Telefone telefone);
    }
}