using CodeChampions.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.Json.Serialization;

namespace CodeChampions.Controllers
{
	public class codeforceController : Controller
	{
		private readonly HttpClient client = new HttpClient();
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult register(string handle)
		{
			Uri uri = new Uri("https://codeforces.com/api/user.info?handles=" + handle);
			client.BaseAddress = uri;
			HttpResponseMessage httpResponseMessage = client.GetAsync(uri).Result;


			

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
				Root root = JsonConvert.DeserializeObject<Root>(data);


				return RedirectToAction("Champion","Champion",root.result.FirstOrDefault());
			}
			else
			{
				return View();
			}

		
		}


		[HttpPost]
		public IActionResult getallContestsfor(string handle)
		{

			TempData["handle"] = handle;
			Console.WriteLine(handle);
			return RedirectToAction("showAllContests","contests");
			

		}
	}
}
