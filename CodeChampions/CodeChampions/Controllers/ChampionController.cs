using CodeChampions.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChampions.Controllers
{
	public class ChampionController : Controller
	{
		public IActionResult Champion(Result res)
		{
			return View(res);
		}
	}
}
