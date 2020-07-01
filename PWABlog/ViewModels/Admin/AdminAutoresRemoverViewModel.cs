namespace PWABlog.ViewModels.Admin
{
	public class AdminAutoresRemoverViewModel : ViewModelAreaAdministrativa
	{
		public int IdAutor { get; set; }

		public string NomeAutor { get; set; }

		public string Erro { get; set; }

		public AdminAutoresRemoverViewModel()
		{
			TituloPagina = "Remover autor: ";
		}
	}
}