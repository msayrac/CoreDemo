using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]

	public class ContactController : Controller
	{

		ContactManager cm = new ContactManager(new EfContactrepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Contact p)
		{
			p.ContactDate = DateTime.Parse(DateTime.Now.ToString());
			p.ContactStatus = true;
			cm.ContactAdd(p);			

			return RedirectToAction("Index","Blog");
		}
	}
}
