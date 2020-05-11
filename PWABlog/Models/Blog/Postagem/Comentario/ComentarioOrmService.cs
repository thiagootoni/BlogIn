using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PWABlog.Models.Blog.Postagem.Comentario
{
    public class ComentarioOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public ComentarioOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ComentarioEntity> ObterTodosComentarios()
        {
            return _databaseContext.Comentarios
                .Include(c => c.Autor)
                .Include(c => c.Postagem)
                .Include(c => c.ComentarioPai)
                .ToList();
        }

    }
}
