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

namespace AdvertSystem.Controllers
{
    public class AdController : Controller
    {
        private readonly Database _context;

        public AdController(Database context)
        {
            _context = context;
        }

        // GET: Ad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ads.Include(m => m.Ads_Annonsor).ToListAsync());
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
		public IActionResult Create(int id)
		{
			// Skickar med id för annonsör.
			ViewBag.AnnonsorId = id;
            // Nödvändig för att viewn ska rendera rätt.
            AdModel am = new();
            return View(am);
        }

        // POST: Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Ads_Id,Ads_Content,Ads_ProductPrice,Ads_Price,Ads_Title")] AdModel adModel)
        {
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
