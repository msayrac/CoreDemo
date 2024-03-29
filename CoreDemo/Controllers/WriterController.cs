﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());

		private readonly UserManager<AppUser> _userManager;
		public WriterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		public IActionResult Index()
		{
			Context c = new Context();
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;			
			var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();

			ViewBag.v2 = writerName;
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public IActionResult WriterMail()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavBarPartial()
		{
			return PartialView();
		}
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}

		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{
			Context c = new Context();
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			UserManager userManager = new UserManager(new EfUserRepository());

			//var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			//var writervalues = wm.TGetById(writerID);
			//return View(writervalues);
			//var username = await _userManager.FindByNameAsync(User.Identity.Name);

			var id =c.Users.Where(x=>x.Email==usermail).Select(y=>y.Id).FirstOrDefault();
			var values = userManager.TGetById(id);		

			return View(values);
		}

		[HttpPost]
		public IActionResult WriterEditProfile(Writer p)
		{
			var pas1 = Request.Form["pass1"];
			var pas2 = Request.Form["pass2"];

			if (pas1 == pas2)
			{
				p.WriterPassword = pas2;
				WriterValidator wl = new WriterValidator();
				ValidationResult results = wl.Validate(p);

				if (results.IsValid)
				{
					wm.TUpdate(p);

					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					foreach (var item in results.Errors)
					{
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					}
				}
			}
			else
			{
				ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
			}
			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage p)
		{
			Writer w = new Writer();
			if (p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);

				p.WriterImage.CopyTo(stream);
				w.WriterImage = newimagename;

			}

			w.WriterMail = p.WriterMail;
			w.WriterName = p.WriterName;
			w.WriterPassword = p.WriterPassword;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;

			wm.TAdd(w);

			return RedirectToAction("Index", "Dashboard");
		}

		



	}
}
