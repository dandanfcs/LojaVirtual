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
        private readonly IProdutoRepository materialRepository;

        public ProdutoController(IProdutoRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult List()
        {
            return View(materialRepository.ListarProdutos());
        }
        public IActionResult Create(Produto produto)
        {
            materialRepository.IncluirProduto(produto);
            return RedirectToAction(nameof(List));
        }
    }
}
