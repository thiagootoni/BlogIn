using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.Models.Blog.Autor
{
    public class AutorOrmService
    {

        private readonly DatabaseContext _databaseContext;

        public AutorOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<AutorEntity> ObterTodosAutores()
        {
            return _databaseContext.Autores.ToList();
        }

        public AutorEntity ObterAutorPorId(int idCategoria)
        {
            var autor = _databaseContext.Autores.Find(idCategoria);

            return autor;
        }

        public List<AutorEntity> PesquisarAutoresPorNome(string nomeAutor)
        {
            return _databaseContext.Autores.Where(c => c.Nome.Contains(nomeAutor)).ToList();
        }

        public AutorEntity CriarAutor(String nome)
        {
            var NovoAutor = new AutorEntity { Nome = nome };
            _databaseContext.Autores.Add(NovoAutor);
            _databaseContext.SaveChanges();

            return NovoAutor;
        }

        public AutorEntity EditarAutor(int id, string nome)
        {
            var Autor = _databaseContext.Autores.Find(id);

            if (Autor == null)
            {
                throw new Exception("Autor não encontrado!");
            }

            Autor.Nome = nome;
            _databaseContext.SaveChanges();
            return Autor;
        }

        public Boolean RemoverAutor(int id)
        {
            var Autor = _databaseContext.Autores.Find(id);

            if (Autor == null)
            {
                throw new Exception("Autor não encontrado!");
            }

            _databaseContext.Autores.Remove(Autor);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
