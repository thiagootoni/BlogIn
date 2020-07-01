using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.ViewModels.Admin
{
	public class AdminAutoresListarViewModel : ViewModelAreaAdministrativa
	{
		public ICollection<AutorAdminAutores> autores { get; set; }
		public AdminAutoresListarViewModel()
		{
			TituloPagina = "Categorias - Administrador";
			autores = new List<AutorAdminAutores>();
		}
	}

	public class AutorAdminAutores
	{
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}