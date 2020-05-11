using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.RequestModels.AdminEtiquetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.Controllers.Admin
{
    public class AdminEtiquetasController : Controller
    {

        private readonly EtiquetaOrmService _etiquetaOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;

        public AdminEtiquetasController(EtiquetaOrmService etiquetaOrmService, CategoriaOrmService categoriaOrmService)
        {
            _etiquetaOrmService = etiquetaOrmService;
            _categoriaOrmService = categoriaOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalhar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminEtiquetasCriarRequestModel request)
        {
            var nome = request.Nome;
            var idCategoria = request.IdCategoria;

            var Categoria = _categoriaOrmService.ObterCategoriaPorId(idCategoria);

            try
            {
                _etiquetaOrmService.CriarEtiqueta(nome, Categoria);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminEtiquetasEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;
            var idCategoria = request.IdCategoria;

            var Categoria = _categoriaOrmService.ObterCategoriaPorId(id);

            try
            {
                _etiquetaOrmService.EditarEtiqueta(id, nome, Categoria);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Editar", new { id = id });
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminEtiquetasRemoverRequest request)
        {
            var id = request.Id;

            try
            {
                _etiquetaOrmService.RemoverEtiqueta(id);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Remover", new { id = id });
            }

            return RedirectToAction("Listar");
        }


    }
}
