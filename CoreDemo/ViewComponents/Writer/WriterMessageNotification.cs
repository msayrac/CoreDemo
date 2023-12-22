using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterMessageNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{

			return View();
		}


	}
}
