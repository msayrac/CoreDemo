using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		private readonly UserManager<AppUser> _userManager;

		Context c = new Context();

		public WriterAboutOnDashboard(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IViewComponentResult Invoke()
		{
			//var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var username = User.Identity.Name;
			ViewBag.veri = username;			
			var usermail =c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();

			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = writerManager.GetWriterById(writerID);
			return View(values);
		}


	}
}
