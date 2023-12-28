﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterMessageNotification : ViewComponent
	{
		MessageManager mm = new MessageManager(new EfMessageRepository());


		public IViewComponentResult Invoke()
		{
			string p;
			p = "deneme@gmail.com";

			var values = mm.GetInboxListByWriter(p);

			return View(values);
		}


	}
}
