using LojaVirtual.Areas.Catalogo.Models;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Executores
{
    public interface IVendasExecutor
    {
        CarrinhoViewModel ResumoDoPedido();
        void RealizarVenda(int id);
    }
}
