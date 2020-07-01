﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.ViewModels.Admin
{
	public class AdminEtiquetasEditarViewModel : ViewModelAreaAdministrativa
	{
		public int IdEtiqueta { get; set; }

		public string NomeEtiqueta { get; set; }

		public int IdCategoriaEtiqueta { get; set; }

		public string Erro { get; set; }

		public ICollection<CategoriaAdminEtiquetas> Categorias { get; set; }

		public AdminEtiquetasEditarViewModel()
		{
			TituloPagina = "Editar Etiqueta: ";

			Categorias = new List<CategoriaAdminEtiquetas>();
		}
	}
}
