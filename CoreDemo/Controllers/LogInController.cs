using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

		//[HttpPost]
		//public async Task<IActionResult> Index(Writer p)
		//{
		//	Context c= new Context();
		//	var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail==p.WriterMail && x.WriterPassword==p.WriterPassword);

		//	if(datavalue!=null)
		//	{

		//		var claims = new List<Claim>
		//		{
		//			new Claim(ClaimTypes.Name,p.WriterMail)
		//		};
		//		var useridentity = new ClaimsIdentity(claims, "a");

		//		ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

		//		await HttpContext.SignInAsync(principal);

		//		return RedirectToAction("Index", "Dashboard");
		//	}
		//	else
		//	{
		//		return View();
		//	}




		//}

	}
}

