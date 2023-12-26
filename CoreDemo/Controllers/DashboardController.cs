using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class DashboardController : Controller
	{
		BlogManager cm = new BlogManager(new EfBlogRepository());

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
	}
}
