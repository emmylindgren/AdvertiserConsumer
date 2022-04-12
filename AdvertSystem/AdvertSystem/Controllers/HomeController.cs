using AdvertSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace AdvertSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly HttpClient _httpClient;

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            // Ange relativa URL-er UTAN / innan.
            _httpClient.BaseAddress = new Uri("https://localhost:7044/api/");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection col) {
           
            
            if(!col.TryGetValue("Select",out var value))
            {
                ViewBag.Error = "No button selected";
                return View();
            }
        
            if( value == "sub")
            {
                //Be om prenumerationsnummer sen hämta från API
                return RedirectToAction("GetSubscriberId");
            }
            else
            {
                return RedirectToAction("Create", "Company");
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> ReviewRecords(int id)
		{
            SubscriberModel subscriber = null;

            try
            {
                subscriber = await GetSubscriberFromAPI(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            return View(subscriber);
		}

        [HttpPost]
        public IActionResult GetSubscriberId(IFormCollection col)
        {
            if (!col.TryGetValue("SubId", out var subId))
            {
                return View();
            }
			
            return RedirectToAction("ReviewRecords", new { id = subId });
        }
		
        [HttpGet]
        public IActionResult GetSubscriberId()
        {
            return View();
        }
		
        [HttpGet]
		public async Task<IActionResult> EditSubscriber(int id)
		{
            SubscriberModel subscriber = null;
			
            try
            {
                subscriber = await GetSubscriberFromAPI(id);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View(subscriber);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<SubscriberModel> GetSubscriberFromAPI(int subId)
		{
            var response = await _httpClient.GetAsync("subscriber/" + subId);

            // Om det ej finns någon prenumerant med angivet prenumerationsnummer
            if ((int)response.StatusCode == 404)
            {
                throw new Exception("Kunde ej hitta en prenumerant med detta prenumerationsnummer. Försök igen.");
            }
            // Om prenumerant hittad
            else if ((int)response.StatusCode == 200)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SubscriberModel>(content)!;
            }
            else
            {
                throw new Exception("Något gick fel, försök igen.");
            }
        }
    }
}