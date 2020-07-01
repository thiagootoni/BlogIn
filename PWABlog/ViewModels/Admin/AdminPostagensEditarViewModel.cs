using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.ViewModels.Admin
{
    public class AdminPostagensEditarViewModel : ViewModelAreaAdministrativa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }
        public string Texto { get; set; }
        public string DataExibicao { get; set; }

        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> CategoriasPostagem { get; set; }
        //public ICollection<AutorAdminPostagens> AutoresPostagem { get; set; }


        public AdminPostagensEditarViewModel()
        {
            TituloPagina = "Editar Postagem: ";
            CategoriasPostagem = new List<CategoriaAdminPostagens>();
            //AutoresPostagem = new List<AutorAdminPostagens>();
        }
    }
}