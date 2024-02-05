using CodeChampions.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CodeChampions.Controllers
{



	public class contestsController : Controller
	{

	

		private readonly HttpClient client = new HttpClient(), client2 = new HttpClient();
		public IActionResult showAllContests()
		{


			Uri uri = new Uri("https://codeforces.com/api/contest.list");
			client.BaseAddress = uri;
			HttpResponseMessage httpResponseMessage = client.GetAsync(uri).Result;



			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
				dataOfContests dataOfContests = JsonConvert.DeserializeObject<dataOfContests>(data);

				Task.Delay(2000).Wait();
				Uri uri2 = new Uri("https://codeforces.com/api/user.status?handle="+ TempData["handle"] + "&from=1");
				client2.BaseAddress = uri2;

				HttpResponseMessage httpResponseMessage2 = client2.GetAsync(uri2).Result;

				if (!httpResponseMessage2.IsSuccessStatusCode)
				{

					return RedirectToAction("register", "codeforce");
				}

				string Submissiondata = httpResponseMessage2.Content.ReadAsStringAsync().Result;
				SubmissionRoot submissionroot = JsonConvert.DeserializeObject<SubmissionRoot>(Submissiondata);

				ViewBag.submissions=submissionroot.result;


				Console.WriteLine(submissionroot.result.Count);
				Console.WriteLine(submissionroot.result.FirstOrDefault().ToString());


				return View(dataOfContests.result.OrderBy(x => x.name).ToList());
			}

			return RedirectToAction("register", "codeforce");
		}
	}
}