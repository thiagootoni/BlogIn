using System.Collections.Generic;

namespace PWABlog.ViewModels.Admin
{
	public class AdminCategoriasRemoverViewModel : ViewModelAreaAdministrativa
	{
		public int IdCategoria { get; set; }

		public string NomeCategoria { get; set; }

		public string Erro { get; set; }

		public AdminCategoriasRemoverViewModel()
		{
			TituloPagina = "Remover Categoria: ";
		}
	}
}