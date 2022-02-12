using LojaDeMateriais.Repositories.Interfaces;
using LojaVirtual.Areas.Catalogo.Models;
using LojaVirtual.Executores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Areas.Catalogo.Controllers
{
    [Area("Catalogo")]
    public class HomeController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IVendasExecutor vendasExecutor;

        public HomeController(IProdutoRepository produtoRepository, IVendasExecutor vendasExecutor)
        {
            this.produtoRepository = produtoRepository;
            this.vendasExecutor = vendasExecutor;
        }

        public IActionResult Index()
        {
            CarrinhoViewModel carrinho = vendasExecutor.ResumoDoPedido();
           

            ViewBag.Resumo = carrinho;
            ViewBag.Produtos = carrinho.Produtos.ToList();

            return View(produtoRepository.ListarProdutos());
        }
    }
}
