#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertSystem.Data;
using AdvertSystem.Models;
using Newtonsoft.Json;

namespace AdvertSystem.Controllers
{
    public class AdController : Controller
    {
        private readonly Database _context;
        private HttpClient _httpClient;
        private string _apiKey = "f6297919273b7f185ed0ad9d1b51eac0";
        private static dynamic exchangeRateValues;

        private List<SelectListItem> exchangeRates = new List<SelectListItem> {
            new SelectListItem(){Text="Amerikansk Dollar", Value="USD"},
			new SelectListItem(){Text="Euro", Value="EUR"},
			new SelectListItem(){Text="Brittiskt Pund", Value="GBP"},
			new SelectListItem(){Text="Japansk Yen", Value="JPY"},
			new SelectListItem(){Text="Svensk Krona", Value="SEK"},
            new SelectListItem(){Text="Norsk Krona", Value="NOK"},
            new SelectListItem(){Text="Rysk Rubel", Value="RUB"},
            new SelectListItem(){Text="Dansk Krona", Value="DKK"},
        };

        public AdController(Database context)
        {
			_httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api.exchangeratesapi.io/v1/");
			_context = context;
        }

        // GET: Ad
        public async Task<IActionResult> Index()
        {
			ViewBag.exchangeRates = exchangeRates;

			return View(await _context.Ads.Include(m => m.Ads_Annonsor).ThenInclude(annonsor => annonsor.An_CoId).ToListAsync());
        }

        // GET: Ad
        public async Task<IActionResult> Index1(string currency)
        {
            ViewBag.exchangeRates = exchangeRates;

            string url = "latest?access_key=" + _apiKey + "&symbols=";

            if(exchangeRateValues is null)
			{
                for (int i = 0; i < exchangeRates.Count; i++)
                {
                    if (i == exchangeRates.Count - 1)
                    {
                        url += exchangeRates[i].Value;
                    }
                    else
                    {
                        url += exchangeRates[i].Value + ",";
                    }
                }
				
                var response = await _httpClient.GetAsync(url);
                string jsonString = await response.Content.ReadAsStringAsync();
				exchangeRateValues = JsonConvert.DeserializeObject(jsonString);
			}
            double swe = exchangeRateValues.rates["SEK"];
            double eur = 1 / swe;
			ViewBag.exchangeRate = eur* (double)exchangeRateValues.rates[currency];
            ViewBag.currencyName = currency;

            return View("Index",await _context.Ads.Include(m => m.Ads_Annonsor).ThenInclude(annonsor => annonsor.An_CoId).ToListAsync());
        }

        // GET: Ad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adModel = await _context.Ads
                .FirstOrDefaultAsync(m => m.Ads_Id == id);
            if (adModel == null)
            {
                return NotFound();
            }

            return View(adModel);
        }

		// GET: Ad/Create
		public async Task<IActionResult> CreateAsync(int id)
		{
            // Nödvändig för att viewn ska rendera rätt.
            AdModel am = new();
            // Skickar med id för annonsör.
            AnnonsorerModel annonsor = await _context.Annonsorer.Include(annonsor => annonsor.An_CoId).FirstOrDefaultAsync(am => am.An_Id == id);

            am.Ads_Annonsor = annonsor;

            if (annonsor.An_CoId == null)
			{
                am.Ads_Price = 0;
            }
			else
			{
                am.Ads_Price = 40;
			}

            ViewBag.An_Id = id;
            return View(am);
        }

        // POST: Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(int id,/*[Bind("Ads_Id,Ads_Content,Ads_ProductPrice,Ads_Price,Ads_Title,Ads_Annonsor")]*/ AdModel adModel)
        {
            AnnonsorerModel annonsor = await _context.Annonsorer.Include(annonsor => annonsor.An_CoId).FirstOrDefaultAsync(am => am.An_Id == id);

            adModel.Ads_Annonsor = annonsor;

            if (ModelState.IsValid)
            {
                _context.Add(adModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adModel);
        }

        // GET: Ad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adModel = await _context.Ads.FindAsync(id);
            if (adModel == null)
            {
                return NotFound();
            }
            return View(adModel);
        }

        // POST: Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ads_Id,Ads_Content,Ads_ProductPrice,Ads_Price,Ads_Title")] AdModel adModel)
        {
            if (id != adModel.Ads_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdModelExists(adModel.Ads_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adModel);
        }

        // GET: Ad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adModel = await _context.Ads
                .FirstOrDefaultAsync(m => m.Ads_Id == id);
            if (adModel == null)
            {
                return NotFound();
            }

            return View(adModel);
        }

        // POST: Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adModel = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(adModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdModelExists(int id)
        {
            return _context.Ads.Any(e => e.Ads_Id == id);
        }
    }
}
