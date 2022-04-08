﻿#nullable disable
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
    public class CompanyController : Controller
    {
        private readonly Database _context;

        public CompanyController(Database context)
        {
            _context = context;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyModel = await _context.Companies
                .FirstOrDefaultAsync(m => m.Co_OrgId == id);
            if (companyModel == null)
            {
                return NotFound();
            }

            return View(companyModel);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Co_OrgId,Co_Name,Co_Telephone,Co_BillStreet,Co_BillPostalCode,Co_BillCity,Co_Steet,Co_PostalCode,Co_City")] CompanyModel companyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyModel);
                await _context.SaveChangesAsync();


                _context.Add(new AnnonsorerModel
                {
                    An_CoId = companyModel
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyModel);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyModel = await _context.Companies.FindAsync(id);
            if (companyModel == null)
            {
                return NotFound();
            }
            return View(companyModel);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Co_OrgId,Co_Name,Co_Telephone,Co_BillStreet,Co_BillPostalCode,Co_BillCity,Co_Steet,Co_PostalCode,Co_City")] CompanyModel companyModel)
        {
            if (id != companyModel.Co_OrgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyModelExists(companyModel.Co_OrgId))
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
            return View(companyModel);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyModel = await _context.Companies
                .FirstOrDefaultAsync(m => m.Co_OrgId == id);
            if (companyModel == null)
            {
                return NotFound();
            }

            return View(companyModel);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyModel = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(companyModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyModelExists(int id)
        {
            return _context.Companies.Any(e => e.Co_OrgId == id);
        }
    }
}
