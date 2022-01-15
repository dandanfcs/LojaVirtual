using LojaDeMateriais.Context;
using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {

        }

        public void IncluirProduto(Produto produto)
        {
            context.Add(produto);
            context.SaveChanges();
        }
        public List<Produto> ListarProdutos()
        {
           return dbSet.ToList();
        }
    }
}
