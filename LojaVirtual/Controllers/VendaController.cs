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
        private readonly IVendaRepository vendaRepository;
        private readonly IVendasRepository vendasRepository;

        public VendaController(IProdutoRepository produtoRepository, IVendaRepository vendaRepository, IVendasRepository vendasRepository)
        {
            this.produtoRepository = produtoRepository;
            this.vendaRepository = vendaRepository;
            this.vendasRepository = vendasRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RealizarVenda(int id)
        {
            Produto produto =  produtoRepository.ObterProduto(id);
            Venda vendaAbertas = vendaRepository.BuscarVendaAberta();
           
            if(vendaAbertas == null)
            {
                var teste = "aaa";
            }
            Vendas venda = new Vendas()
            {
                idProduto = produto.Id,
                idVenda = vendaAbertas.Id,
                data = DateTime.Now
            };

            vendasRepository.InserirVenda(venda);

           return RedirectToAction("List", "Produto");
        }

        public IActionResult FinalizarVenda()
        {
            return View();
        }
    }
}
