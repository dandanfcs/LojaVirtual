using LojaDeMateriais.Context;
using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class VendasRepository: BaseRepository<Vendas>, IVendasRepository
    {
        public VendasRepository(ApplicationContext context) : base(context)
        {

        }

        public List<Vendas> BuscarVendasRealizadasPorId(int id)
        {
            var lista = dbSet.Where(v => v.IdPedido == id).ToList();
            return lista;
        }

        public void VerificarSeProdutoExisteNoCarrinho(int id)
        {
            var produto = dbSet.Where(p => p.IdProduto == id).FirstOrDefault();
            produto.Quantidade++;
            context.SaveChanges();
        }

        public void InserirProduto(Vendas vendas)
        {
            context.Add(vendas);
            context.SaveChanges();
        }
    }
}

