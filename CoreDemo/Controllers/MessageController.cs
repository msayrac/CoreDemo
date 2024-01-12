using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class MessageController : Controller
	{

		Message2Manager mm = new Message2Manager(new EfMessage2Repository());
		Context c = new Context();
		public IActionResult InBox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

			var values = mm.GetInboxListByWriter(writerID);
			return View(values);
		}
		public IActionResult MessageDetails(int id)
		{
			var value = mm.TGetById(id);
			return View(value);
		}
	}
}
