using AdvertSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvertSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Company");
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}