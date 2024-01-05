using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreDemo.Controllers
{
	public class EmployeTestController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var httpClient = new HttpClient();
			var responseMessage = await httpClient.GetAsync("https://localhost:44309/api/Default");
			var jsonString = await responseMessage.Content.ReadAsStringAsync();

			var values = JsonConvert.DeserializeObject<List<Class2>>(jsonString);

			return View(values);
		}

		[HttpGet]
		public IActionResult AddEmployee()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddEmployee(Class2 p)
		{
			var httpClient = new HttpClient();
			var jsonEmployee = JsonConvert.SerializeObject(p);

			StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
			var responseMessage = await httpClient.PostAsync("https://localhost:44309/api/Default", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(p);
		}

	}

	public class Class2
	{
		public int ID { get; set; }
		public string Name { get; set; }

	}
}

