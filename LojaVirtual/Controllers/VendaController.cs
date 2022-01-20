using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories.Interfaces;
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

        public IActionResult FinalizarVenda()
        {
            return View();
        }
    }
}
