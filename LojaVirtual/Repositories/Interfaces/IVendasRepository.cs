using LojaDeMateriais.Models;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Interfaces
{
   public interface IVendasRepository
    {
        void InserirProduto(Vendas vendas);
        List<Vendas> BuscarVendasRealizadasPorId(int id);
        bool VerificarSeProdutoExisteNoCarrinho(int id);
    }
}
