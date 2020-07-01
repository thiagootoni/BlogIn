using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;
using PWABlog.RequestModels.AdminAutores;
using PWABlog.RequestModels.AdminPostagens;
using PWABlog.ViewModels.Admin;

namespace PWABlog.Controllers.Admin
{

  [Authorize]
    public class AdminPostagensController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly AutorOrmService _autoresOrmService;
        private readonly RevisaoOrmService _revisaoOrmService;

        public AdminPostagensController(
            PostagemOrmService postagemOrmService,
            CategoriaOrmService categoriaOrmService,
            AutorOrmService autoresOrmService,
            RevisaoOrmService revisaoOrmService
        )
        {
            _postagemOrmService = postagemOrmService;
            _categoriaOrmService = categoriaOrmService;
            _autoresOrmService = autoresOrmService;
            _revisaoOrmService = revisaoOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminPostagensListarViewModel model = new AdminPostagensListarViewModel();

            var listaPostagens = _postagemOrmService.ObterPostagens();

            foreach (var postagemEntity in listaPostagens)
            {
                //var categoria = _categoriaOrmService.ObterCategoriaPorId(postagemEntity.Categoria.Id);
                //var autor = _autoresOrmService.ObterAutorPorId(postagemEntity.Autor.Id);

                var postagemAdminPostagens = new PostagemAdminPostagens();
                postagemAdminPostagens.Id = postagemEntity.Id;
                postagemAdminPostagens.Titulo = postagemEntity.Titulo;
                postagemAdminPostagens.NomeAutor = postagemEntity.Autor.Nome;
                postagemAdminPostagens.Categoria = postagemEntity.Categoria.Nome;
                postagemAdminPostagens.DataExibição = postagemEntity.DataExibicao;

                model.Postagens.Add(postagemAdminPostagens);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            AdminPostagensCriarViewModel model = new AdminPostagensCriarViewModel();

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Obter as Categorias
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            // Alimentar o model com as categorias que serão colocadas no <select> do formulário
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminPostagens = new CategoriaAdminPostagens();
                categoriaAdminPostagens.IdCategoria = categoriaEntity.Id;
                categoriaAdminPostagens.NomeCategoria = categoriaEntity.Nome;

                model.CategoriasPostagem.Add(categoriaAdminPostagens);
            }

            // Obter os Autores
            var listaAutores = _autoresOrmService.ObterAutores();

            // Alimentar o model com as Autores que serão colocadas no <select> do formulário
            foreach (var autorEntity in listaAutores)
            {
                var autorAdminPostagens = new AutorAdminPostagens();
                autorAdminPostagens.IdAutor = autorEntity.Id;
                autorAdminPostagens.NomeAutor = autorEntity.Nome;

                model.AutoresPostagem.Add(autorAdminPostagens);
            }

            return View(model);

        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminPostagemCriarRequestModel request)
        {
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var idAutor = request.IdAutor;
            var idCategoria = request.IdCategoria;
            var texto = request.Texto;
            var dataExibicao = DateTime.Parse(request.DataExibicao);
             

            try
            {
                _postagemOrmService.CriarPostagem(titulo, descricao, idAutor, idCategoria, texto, dataExibicao);
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
            AdminPostagensEditarViewModel model = new AdminPostagensEditarViewModel();

            // Obter categoria a editar
            var postagenAEditar = _postagemOrmService.ObterPostagemPorId(id);
            if (postagenAEditar == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            model.Id = postagenAEditar.Id;
            model.IdCategoria = postagenAEditar.Categoria.Id;
            model.Titulo = postagenAEditar.Titulo;
            model.Descricao = postagenAEditar.Descricao;
            model.Texto = postagenAEditar.Revisoes.ToString();
            //model.TituloPagina += model.Titulo;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminPostagemEditarRequestModel request)
        {
            var id = request.Id;
            var titulo = request.Texto;
            var descricao = request.Descricao;
            var idCategoria = Convert.ToInt32(request.IdCategoria);
            var texto = request.Texto;
            var dataExibicao = DateTime.Parse(request.DataExibicao);

            try
            {
                _postagemOrmService.EditarPostagem(id, titulo, descricao, idCategoria, texto, dataExibicao);
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
        public RedirectToActionResult Remover(AdminPostagemRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _postagemOrmService.RemoverPostagem(id);
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