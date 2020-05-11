using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;
using PWABlog.RequestModels.AdminPostagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.Controllers.Admin
{
    public class AdminPostagensController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        private readonly RevisaoOrmService _revisaoOrmService;
        private readonly AutorOrmService _autorOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly EtiquetaOrmService _etiquetaOrmService;

        public AdminPostagensController(PostagemOrmService postagemOrmService, RevisaoOrmService revisaoOrmService, 
            AutorOrmService autorOrmService, CategoriaOrmService categoriaOrmService, EtiquetaOrmService etiquetaOrmService)
        {
            _postagemOrmService = postagemOrmService;
            _revisaoOrmService = revisaoOrmService;
            _autorOrmService = autorOrmService;
            _categoriaOrmService = categoriaOrmService;
            _etiquetaOrmService = etiquetaOrmService;
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
        public RedirectToActionResult Criar(AdminPostagensCriarRequestModel request)
        {
            var Titulo = request.Titulo;
            var Descricao = request.Descricao;
            var Autor = _autorOrmService.ObterAutorPorId(Convert.ToInt32(request.IdAutor));
            var Categoria = _categoriaOrmService.ObterCategoriaPorId(Convert.ToInt32(request.IdCategoria));
            var Texto = request.Texto;

            try
            {
                var Postagem = _postagemOrmService.CriarPostagem(Titulo, Descricao, Autor, Categoria);
                _revisaoOrmService.CriarRevisao(Postagem, Texto);
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
        public RedirectToActionResult Editar(AdminPostagensEditarRequestModel request)
        {
            var id = request.Id;
            var Titulo = request.Titulo;
            var Descricao = request.Descricao;
            var Autor = _autorOrmService.ObterAutorPorId(Convert.ToInt32(request.IdAutor));
            var Categoria = _categoriaOrmService.ObterCategoriaPorId(Convert.ToInt32(request.IdCategoria));
            var Texto = request.Texto;

            try
            {
                _postagemOrmService.EditarPostagem(id, Titulo, Descricao, Autor, Categoria);
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
        public RedirectToActionResult Remover(AdminPostagensRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _postagemOrmService.ExcluirPostagem(id);
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
