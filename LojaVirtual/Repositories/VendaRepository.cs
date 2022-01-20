using LojaDeMateriais.Context;
using LojaDeMateriais.Repositories;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(ApplicationContext context) : base(context)
        {

        }

        public Venda BuscarVendaAberta()
        {
          var venda = dbSet.ToList().Where(v => v.VendaFechada == false).First();
            return venda;
        }

        public void InicializarPedido(Venda venda)
        {
            context.Add(venda);
            context.SaveChanges();
        }
    }
}

