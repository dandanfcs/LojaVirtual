using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            this.colaboradorRepository = colaboradorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(Colaborador colaborador)
        {
            colaboradorRepository.AdicionarColaborador(colaborador);
            return RedirectToAction(nameof(Index));
        }
    }
}
