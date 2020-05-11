using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PWABlog.Models.Blog.Postagem.Revisao
{
    public class RevisaoOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public RevisaoOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<RevisaoEntity> ObterTodasRevisoes()
        {
            return _databaseContext.Revisoes.Include(r => r.Postagem).ToList();
        }

        public RevisaoEntity CriarRevisao(PostagemEntity postagem, string texto)
        {
            RevisaoEntity NovaRevisao = new RevisaoEntity { Postagem = postagem, Texto = texto, Versao = 1, DataCriacao = DateTime.Today };
            _databaseContext.Revisoes.Add(NovaRevisao);
            _databaseContext.SaveChanges();
            return NovaRevisao;
        }

        public RevisaoEntity EditarRevisao(int id, string texto, DateTime dataCriacao)
        {
            var Revisao = _databaseContext.Revisoes.Find(id);

            if (Revisao == null)
            {
                throw new Exception("Revisão não encontrada!");
            }

            Revisao.Texto = texto;
            Revisao.Versao++;
            Revisao.DataCriacao = DateTime.Today;

            return Revisao;
        }

        public bool ExcluirRevisao(int id)
        {
            var Revisao = _databaseContext.Revisoes.Find(id);

            if (Revisao == null)
            {
                throw new Exception("Revisão não encontrada!");
            }

            _databaseContext.Revisoes.Remove(Revisao);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}
