﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.RequestModels.ControleDeAcesso
{
	public class ControleDeAcessoRegistrarRequestModel
	{
		public string Email { get; set; }

		public string Apelido { get; set; }

		public string Senha { get; set; }

		public string Token { get; set; }
	}
}
