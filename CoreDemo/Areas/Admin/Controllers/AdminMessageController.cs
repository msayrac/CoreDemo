﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	public class AdminMessageController : Controller
	{
		Message2Manager mm = new Message2Manager(new EfMessage2Repository());
		Context c = new Context();
		public IActionResult Inbox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			//var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var writerID = 1;
			var values = mm.GetInboxListByWriter(writerID);
			return View(values);
		}


		public IActionResult SendBox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			//var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var writerID = 1;
			var values = mm.GetInboxListByWriter(writerID);
			return View(values);
		}

		[HttpGet]
		public IActionResult ComposeMessage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ComposeMessage(Message2 p)
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			//var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var writerID = 1;

			p.SenderID = writerID;
			p.ReceiverID = 3;
			p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.MessageStatus = true;
			mm.TAdd(p);
			return RedirectToAction("SendBox");

		}






	}
}