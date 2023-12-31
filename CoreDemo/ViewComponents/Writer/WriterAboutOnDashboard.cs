﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		Context c = new Context();

		public IViewComponentResult Invoke()
		{
			var usermail = User.Identity.Name;
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

			var values = writerManager.GetWriterById(writerID);
			return View(values);
		}


	}
}
