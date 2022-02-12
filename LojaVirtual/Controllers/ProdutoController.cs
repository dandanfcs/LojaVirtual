using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        

        public ProdutoController(IProdutoRepository materialRepository)
        {
            this.produtoRepository = materialRepository;
        }

        public IActionResult Criar()
        {            
            return View();
        }
        public IActionResult List()
        {
            return View(produtoRepository.ListarProdutos());
        }
        public IActionResult Create(Produto produto)
        {
            produtoRepository.IncluirProduto(produto);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Detalhes(int id)
        {
           var produto = produtoRepository.ObterProduto(id);
           return View(produto);
        }
    }
}
