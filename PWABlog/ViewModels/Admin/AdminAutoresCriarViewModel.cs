namespace PWABlog.ViewModels.Admin
{
	public class AdminAutoresCriarViewModel : ViewModelAreaAdministrativa
	{
		public string Erro { get; set; }
		public AdminAutoresCriarViewModel()
		{
			TituloPagina = "Registra novo autor";

		}
	}

}
