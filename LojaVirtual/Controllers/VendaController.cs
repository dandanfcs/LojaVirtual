using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories.Interfaces;
using LojaVirtual.Dtos;
using LojaVirtual.Executores;
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
        private readonly IVendasExecutor vendasExecutor;

        public VendaController(IProdutoRepository produtoRepository, IPedidoRepository vendaRepository,
            IVendasRepository vendasRepository, IVendasExecutor VendasExecutor)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = vendaRepository;
            this.vendasRepository = vendasRepository;
            this.vendasExecutor = VendasExecutor;
        }

        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public IActionResult RealizarVenda([FromBody] int id)
        {
            vendasExecutor.RealizarVenda(id);
            return RedirectToAction("List", "Produto");
        }

        public IActionResult Resumo()
        {
            var resumo = vendasExecutor.ResumoDoPedido();

            ViewBag.Resumo = resumo;
            ViewBag.Produtos = resumo.Produtos.ToList();

            return View();

        }


    }
}
