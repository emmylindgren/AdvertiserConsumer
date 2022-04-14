using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AdvertSystem.Controllers
{
	public class XmlController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(IFormFile uploadFile)
		{
			HttpClient client = new();
			var file = new StreamContent(uploadFile.OpenReadStream());
			file.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

			var content = new MultipartFormDataContent();
			content.Add(file, "uploadFile", uploadFile.FileName);

			var response = await client.PostAsync("https://localhost:7044/api/xml/", content);

			if (response.IsSuccessStatusCode)
			{
				TempData["Success"] = "Insättningen lyckades.";
			}
			else
			{
				TempData["Error"] = "Insättningen misslyckades. Se stack trace: ";
				TempData["Error"] += await response.Content.ReadAsStringAsync();
			}

			return View("Index");
		}
	}
}
