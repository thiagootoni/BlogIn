using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.RequestModels.AdminPostagens
{
    public class AdminPostagensCriarRequestModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string IdAutor { get; set; }
        public string IdCategoria { get; set; }
        public List<string> IdEtiquetas { get; set; }
        public string IdRevisao { get; set; }
        public string Texto { get; set; }
        public string Versao { get; set; }
        public string DataCriacao { get; set; }

    }
}
