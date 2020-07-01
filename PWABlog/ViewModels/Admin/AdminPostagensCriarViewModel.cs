using System.Collections.Generic;

namespace PWABlog.ViewModels.Admin
{
    public class AdminPostagensCriarViewModel : ViewModelAreaAdministrativa
    {
        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> CategoriasPostagem { get; set; }
        public ICollection<AutorAdminPostagens> AutoresPostagem { get; set; }


        public AdminPostagensCriarViewModel()
        {
            TituloPagina = "Criar nova Postagem";
            CategoriasPostagem = new List<CategoriaAdminPostagens>();
            AutoresPostagem = new List<AutorAdminPostagens>();
        }
    }

    public class CategoriaAdminPostagens
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
    }

    public class AutorAdminPostagens
    {
        public int IdAutor { get; set; }
        public string NomeAutor { get; set; }
    }
}