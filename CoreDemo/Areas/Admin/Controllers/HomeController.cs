using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
	[AllowAnonymous]

	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
