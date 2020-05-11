using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PWABlog.Models.Blog.Categoria;

namespace PWABlog.Models.Blog.Etiqueta
{
    public class EtiquetaOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public EtiquetaOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<EtiquetaEntity> ObterTodasEtiquetas()
        {
            return _databaseContext.Etiquetas.Include(e => e.Categoria).ToList();
        }

        public EtiquetaEntity CriarEtiqueta(string nome, CategoriaEntity categoria)
        {
            EtiquetaEntity NovaEtiqueta = new EtiquetaEntity { Nome = nome, Categoria = categoria };
            _databaseContext.Etiquetas.Add(NovaEtiqueta);
            _databaseContext.SaveChanges();
            return NovaEtiqueta;

        }

        public EtiquetaEntity EditarEtiqueta(int id, string nome, CategoriaEntity categoria )
        {
            var Etiqueta = _databaseContext.Etiquetas.Find(id);

            if (Etiqueta == null)
            {
                throw new Exception("Etiqueta não encontrada!");
            }

            Etiqueta.Nome = nome;
            Etiqueta.Categoria = categoria;
            _databaseContext.SaveChanges();

            return Etiqueta;
        }

        public bool RemoverEtiqueta (int id)
        {
            var Etiqueta = _databaseContext.Etiquetas.Find(id);

            if (Etiqueta == null)
            {
                throw new Exception("Etiqueta não encontrada!");
            }

            _databaseContext.Etiquetas.Remove(Etiqueta);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
