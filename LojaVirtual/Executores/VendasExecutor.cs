using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories.Interfaces;
using LojaVirtual.Dtos;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Executores
{
    public class VendasExecutor : IVendasExecutor
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IVendasRepository vendasRepository;
     
        public VendasExecutor(IProdutoRepository produtoRepository, IPedidoRepository vendaRepository,
            IVendasRepository vendasRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = vendaRepository;
            this.vendasRepository = vendasRepository;
        }

        public void RealizarVenda(int id)
        {
            Produto produto = produtoRepository.ObterProduto(id);
            Pedido pedidoAberto = pedidoRepository.BuscarPedidoAberto(); //verifica se o pedido esta aberto

            if(pedidoAberto != null)
            {
                //vai ir na venda e pesquisar se o produto já existe na venda
                //Se existir, aumentar a quantidade
               
                vendasRepository.VerificarSeProdutoExisteNoCarrinho(produto.Id);
                return;

            }//Senão, insere um novo produto

            if (pedidoAberto == null)
            {
                var teste = "aaa";
            }
            Vendas venda = new Vendas()
            {
                IdProduto = produto.Id,
                IdPedido = pedidoAberto.Id,
                Data = DateTime.Now
            };

            vendasRepository.InserirProduto(venda);

        }


        public Resumo ResumoDoPedido()
        {
            Pedido pedidoAberto = pedidoRepository.BuscarPedidoAberto();//vai buscar o primeiro pedido aberto da lista

            var vendaRealizada = vendasRepository.BuscarVendasRealizadasPorId(pedidoAberto.Id);
            //Retorna as vendas com o id do pedido aberto


            List<Produto> produtoList = new List<Produto>();

            foreach (var list in vendaRealizada)
            {
                Produto produto = produtoRepository.ObterProduto(list.IdProduto); //obtem os produtos através do ID
                produto.Quantidade = list.Quantidade;
                produtoList.Add(produto);

            }

            var valorDaCompra = produtoList.Sum(p => p.ValorTotal());

            Resumo resumo = new Resumo()
            {
                Vendas = vendaRealizada,
                Produtos = produtoList,
                ValorTotal = valorDaCompra
            };

            return resumo;
        }
    }
}
