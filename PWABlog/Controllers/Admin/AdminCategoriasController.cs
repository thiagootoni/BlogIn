using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Categoria;
using PWABlog.RequestModels.AdminCategorias;
using System;
using PWABlog.ViewModels.Admin;

namespace PWABlog.Controllers.Admin
{
    public class AdminCategoriasController : Controller
    {
        private readonly CategoriaOrmService _categoriaOrmService;

        public AdminCategoriasController(
            CategoriaOrmService categoriaOrmService
        )
        {
            _categoriaOrmService = categoriaOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminCategoriasListarViewModel model = new AdminCategoriasListarViewModel();

            // Obter as Categorias
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            // Alimentar o model com as etiquetas que serão listadas
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminCategorias = new CategoriaAdminCategorias();
                categoriaAdminCategorias.Id = categoriaEntity.Id;
                categoriaAdminCategorias.Nome = categoriaEntity.Nome;

                model.Categorias.Add(categoriaAdminCategorias);
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            AdminCategoriasCriarViewModel model = new AdminCategoriasCriarViewModel();

            model.Erro = (string)TempData["erro-msg"];

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminCategoriasCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.CriarCategoria(nome);
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
            AdminCategoriasEditarViewModel model = new AdminCategoriasEditarViewModel();

            // Obter categoria a editar
            var categoriaAEditar = _categoriaOrmService.ObterCategoriaPorId(id);
            if (categoriaAEditar == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da categoria a ser editada

            model.IdCategoria = categoriaAEditar.Id;
            model.NomeCategoria = categoriaAEditar.Nome;
            model.TituloPagina += model.NomeCategoria;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminCategoriasEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.EditarCategoria(id, nome);
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
            AdminCategoriasRemoverViewModel model = new AdminCategoriasRemoverViewModel();

            // Obter etiqueta a remover
            var ARemover = _categoriaOrmService.ObterCategoriaPorId(id);
            if (ARemover == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da etiqueta a ser editada
            model.IdCategoria = ARemover.Id;
            model.NomeCategoria = ARemover.Nome;
            model.TituloPagina += model.NomeCategoria;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminCategoriasRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _categoriaOrmService.RemoverCategoria(id);
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