using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.API.Persistence
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(e =>
            {
                e.HasKey(c => c.Id); // configura chave primaria

                //Configurando o relacionamento da tabela
                e.HasMany(c => c.Telefone) // um contato tem um numero
                .WithOne()
                .HasForeignKey(t => t.IdContato); // qual a foreign key ? 

            }
            );

            modelBuilder.Entity<Telefone>(e =>
            {
                e.HasKey(t => t.Id);

            });
        }


    }

}