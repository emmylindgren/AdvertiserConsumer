using Microsoft.AspNetCore.Mvc;

namespace AdvertSystem.Controllers
{
	public class XmlController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Get()
		{
			return View();
		}
	}
}
