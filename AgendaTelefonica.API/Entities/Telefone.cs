using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.API.Entities
{
    public class Telefone
    {
        public Telefone(string numero, int idContato)
        {
            Numero = numero;
            IdContato = idContato;
        }
        public int Id { get; private set; }
        
        [StringLength(16)]
        [Column(TypeName = "varchar(16)")]
        public string Numero { get; set; }
        public int IdContato { get; private set; }

        public void Atualizar(string numero)
        {
            Numero = numero;
        }
    }
}