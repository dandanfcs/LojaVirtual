using LojaDeMateriais.Models;
using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Context
{
    public class ApplicationContext : DbContext
    {
        //Registra no banco de dados as entidades da aplicação
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Colaborador>().HasKey(c => c.Id);

            modelBuilder.Entity<Produto>().HasKey(m => m.Id);

            modelBuilder.Entity<Pedido>().HasKey(m => m.Id);

            modelBuilder.Entity<Vendas>().HasKey(v => v.Id);
        }
    }
}
