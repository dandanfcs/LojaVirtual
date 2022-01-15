using LojaDeMateriais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Repositories.Interfaces
{
   public interface IProdutoRepository
    {
        void IncluirProduto(Produto material);
        List<Produto> ListarProdutos();
    }
}
