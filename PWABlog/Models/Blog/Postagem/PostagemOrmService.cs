using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;

namespace PWABlog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                .ToList();
        }

        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                .OrderByDescending(p => p.Comentarios.Count)
                .ToList();
        }

        public PostagemEntity CriarPostagem(string titulo, string Descricao, AutorEntity autor, CategoriaEntity categoria)
        {
            var NovaPostagem = new PostagemEntity { Autor = autor, Categoria = categoria, Descricao = Descricao, Titulo = titulo };
            _databaseContext.Postagens.Add(NovaPostagem);
            _databaseContext.SaveChanges();
            return NovaPostagem;
        }

        public PostagemEntity EditarPostagem(int id, string titulo, string Descricao, AutorEntity autor, CategoriaEntity categoria)
        {
            var Postagem = _databaseContext.Postagens.Find(id);

            if (Postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            Postagem.Titulo = titulo;
            Postagem.Descricao = Descricao;
            Postagem.Autor = autor;
            Postagem.Categoria = categoria;

            return Postagem;
        }

        public bool ExcluirPostagem(int id)
        {
            var Postagem = _databaseContext.Postagens.Find(id);

            if (Postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            _databaseContext.Postagens.Remove(Postagem);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}