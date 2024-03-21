using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.API.Entities
{
    public class Contato
    {
        public Contato(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;

        }
        public int Id { get; private set; }
        [StringLength(100)]  // nivel da aplicação
        [Column(TypeName = "varchar(100)")] //Nivel bando de dados
        public string Nome { get; private set; }

        public int Idade { get; private set; }

        public List<Telefone> Telefone { get; private set; }

        public void Atualizar(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}