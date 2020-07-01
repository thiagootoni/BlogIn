using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Autor;
using PWABlog.RequestModels.AdminAutores;
using PWABlog.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.Controllers.Admin
{
	 public class AdminAutoresController : Controller
    {
        private readonly AutorOrmService _autoresOrmService;

        public AdminAutoresController(
            AutorOrmService autoresOrmService
        )
        {
            _autoresOrmService = autoresOrmService;
        }

        [HttpGet]
        //[Route("admin/autores")]
        //[Route("admin/autores/listar")]
        public IActionResult Listar()
        {
            AdminAutoresListarViewModel model = new AdminAutoresListarViewModel();

            var listaAutores = _autoresOrmService.ObterAutores();

            foreach (var autoresEntity in listaAutores)
            {
                var autorAdminAutores = new AutorAdminAutores();
                autorAdminAutores.Id = autoresEntity.Id;
                autorAdminAutores.Nome = autoresEntity.Nome;

                model.autores.Add(autorAdminAutores);
            }

            return View(model);
        }

        [HttpGet]
        //[Route("admin/autores/{id}")]
        public IActionResult Detalhar(int id)
        {
            return View();
        }

        [HttpGet]
        //[Route("admin/autores/criar")]
        public IActionResult Criar()
        {
            AdminAutoresCriarViewModel model = new AdminAutoresCriarViewModel();

            model.Erro = (string)TempData["erro-msg"];

            return View(model);
        }

        [HttpPost]
        //[Route("admin/autores/criar")]
        public RedirectToActionResult Criar(AdminAutoresCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _autoresOrmService.CriarAutor(nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        //[Route("admin/autores/editar/{id}")]
        public IActionResult Editar(int id)
        {
            AdminAutoresEditarViewModel model = new AdminAutoresEditarViewModel();

            // Obter categoria a editar
            var autorAEditar = _autoresOrmService.ObterAutorPorId(id);
            if (autorAEditar == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            model.IdAutor = autorAEditar.Id;
            model.NomeAutor = autorAEditar.Nome;
            model.TituloPagina += model.NomeAutor;

            return View(model);
        }

        [HttpPost]
        //[Route("admin/autores/editar/{id}")]
        public RedirectToActionResult Editar(AdminAutoresEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _autoresOrmService.EditarAutor(id, nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Editar", new { id = id });
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        //[Route("admin/autores/remover/{id}")]
        public IActionResult Remover(int id)
        {
            AdminAutoresRemoverViewModel model = new AdminAutoresRemoverViewModel();

            // Obter etiqueta a remover
            var ARemover = _autoresOrmService.ObterAutorPorId(id);
            if (ARemover == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da etiqueta a ser editada
            model.IdAutor = ARemover.Id;
            model.NomeAutor = ARemover.Nome;
            model.TituloPagina += model.NomeAutor;

            return View(model);
        }

        [HttpPost]
        //[Route("admin/autores/remover/{id}")]
        public RedirectToActionResult Remover(AdminAutoresRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _autoresOrmService.RemoverAutor(id);
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