﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class DashboardController : Controller
	{
		BlogManager cm = new BlogManager(new EfBlogRepository());

		public IActionResult Index()
		{
			Context c = new Context();
			ViewBag.v1 = c.Blogs.Count().ToString();
			ViewBag.v2 =c.Blogs.Where(x=>x.WriterID==1).Count();
			ViewBag.v3 = c.Categories.Count();

			return View();
		}

	}
}
