﻿using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using PWABlog.Models.ControleDeAcesso;

namespace PWABlog.Models.ControledeAcesso
{
	public class ControleDeAcessoService
	{
		private readonly UserManager<Usuario> _userManager;
		private readonly SignInManager<Usuario> _signInManager;

		public ControleDeAcessoService(
				UserManager<Usuario> userManager,
				SignInManager<Usuario> signInManager
		)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task AutenticarUsuario(string usuario, string senha)
		{
			var result = await _signInManager.PasswordSignInAsync(usuario, senha, false, false);

			if (!result.Succeeded)
			{
				throw new Exception("Usuário ou senha inválidos");
			}
		}

		public void DeslogarUsuario()
		{
			_signInManager.SignOutAsync();
		}

		public async Task RegistrarUsuario(string email, string apelido, string senha)
		{
			var user = new Usuario
			{
				UserName = email,
				Email = email,
				Apelido = apelido
			};

			var result = await _userManager.CreateAsync(user, senha);

			if (!result.Succeeded)
			{
				throw new RegistrarUsuarioException(result.Errors);
			}
		}
	}
}