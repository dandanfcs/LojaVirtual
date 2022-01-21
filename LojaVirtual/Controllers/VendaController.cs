using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories.Interfaces;
using LojaVirtual.Dtos;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class VendaController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IVendasRepository vendasRepository;

        public VendaController(IProdutoRepository produtoRepository, IPedidoRepository vendaRepository, 
            IVendasRepository vendasRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = vendaRepository;
            this.vendasRepository = vendasRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RealizarVenda(int id)
        {
            Produto produto =  produtoRepository.ObterProduto(id);
            Pedido pedidoAberto = pedidoRepository.BuscarPedidoAberto();
           
            if(pedidoAberto == null)
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

           return RedirectToAction("List", "Produto");
        }

        public IActionResult Resumo()
        {
            Pedido pedidoAberto = pedidoRepository.BuscarPedidoAberto();//vai buscar o primeiro pedido aberto da lista
                                                                        
           var vendaRealizada = vendasRepository.BuscarVendasRealizadasPorId(pedidoAberto.Id);
            //Retorna as vendas com o id do pedido aberto
            List<Produto> produtoList = new List<Produto>();

            foreach(var list in vendaRealizada)
            {
                Produto produto = produtoRepository.ObterProduto(list.IdProduto);
                produtoList.Add(produto);

            }

            var valorDaCompra = produtoList.Sum(p => p.Preco);

            Resumo resumo = new Resumo()
            {
                Vendas = vendaRealizada,
                Produtos = produtoList,
                ValorTotal = valorDaCompra
            };

            ViewBag.Resumo = resumo;
            ViewBag.Produtos = resumo.Produtos.ToList();

            return View();
            // return RedirectToAction("Resumo", "Venda", resumo);
        }

       /* public IActionResult Resumo()
        {
            ViewBag.Resumo = resumo;
            ViewBag.Produtos = resumo.Produtos.ToList();
            return View();
        }
       */
    }
}
