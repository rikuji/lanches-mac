using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }
        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.Nome.Equals("Normal")).OrderBy(p => p.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.Nome.Equals("Natural")).OrderBy(p => p.Nome);
                }

                categoriaAtual = _categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            if (lanche == null)
            {
                return View("~/View/Error/Error.cshtml");
            }

            return View(lanche);
        }
    }
}