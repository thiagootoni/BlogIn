﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.RequestModels.AdminEtiquetas
{
	public class AdminEtiquetasCriarRequestModel
	{
		public int Id { get; set; }

		public string Nome { get; set; }

		public int IdCategoria { get; set; }
	}
}
