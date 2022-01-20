using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void InicializarPedido(Pedido pedido);
        Pedido BuscarPedidoAberto();
    }
}
