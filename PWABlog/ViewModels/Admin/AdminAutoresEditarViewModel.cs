namespace PWABlog.ViewModels.Admin
{
	public class AdminAutoresEditarViewModel : ViewModelAreaAdministrativa
	{
		public int IdAutor { get; set; }

		public string NomeAutor { get; set; }
		public string Erro { get; set; }
		public AdminAutoresEditarViewModel()
		{
			TituloPagina = "Editar Categoria: ";

		}
	}

}
