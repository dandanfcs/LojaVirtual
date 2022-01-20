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
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationContext context) : base(context)
        {

        }

        public Pedido BuscarPedidoAberto()
        {
          var pedido = dbSet.ToList().Where(p => p.PedidoFechado == false).First();
          return pedido;
        }

        public void InicializarPedido(Pedido pedido)
        {
            context.Add(pedido);
            context.SaveChanges();
        }
    }
}

