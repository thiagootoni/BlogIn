using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.Models.Blog.Postagem.Comentario
{
	public class ComentarioOrmService
	{
		private readonly DatabaseContext _databaseContext;

		public ComentarioOrmService(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public ComentarioEntity ObterComentarioPorId(int id)
		{
			var comentario = _databaseContext.Comentarios.Find(id);

			return comentario;
		}

	}
}
