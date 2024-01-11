using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class LogInController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LogInController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[AllowAnonymous]

		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]

		[HttpPost]
		public async Task<IActionResult> Index(UserSignInViewModel p)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}

		
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "LogIn");
		}

	}
}

