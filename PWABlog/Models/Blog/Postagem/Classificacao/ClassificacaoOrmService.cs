using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PWABlog.Models.Blog.Postagem.Classificacao
{
    public class ClassificacaoOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public ClassificacaoOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<ClassificacaoEntity> ObterTodasClassificacoes()
        {
            return _databaseContext.Classificacoes.Include(c => c.Postagem).ToList();
        }
    }
}
