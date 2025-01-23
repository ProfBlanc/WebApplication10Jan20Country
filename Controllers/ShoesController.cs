using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication10Jan20Country.Data;
using WebApplication10Jan20Country.Models;

namespace WebApplication10Jan20Country.Controllers
{
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shoes.Include(s => s.Country);

            return View(await applicationDbContext.ToListAsync());  //Model rep data
        }

        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.ShoeID == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoes/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ShoeOrginCountry"] = new SelectList(_context.Countries, "CountryID", "DisplayNameForFKDropDown");
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ShoeID,ShoeName,ShoeColor,ShoeOrginCountry,ShoeImageUpload")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                if (shoe.ShoeImageUpload != null) {
                    //someone has uploaded an image
                    string fileName = Path.GetFileName(shoe.ShoeImageUpload.FileName);
                    //we can decide to change the filename
                    string ext = Path.GetExtension(shoe.ShoeImageUpload.FileName);

                    shoe.ShoeImage = fileName + ext;

                    shoe.ShoeImageUpload.CopyTo(
                        new FileStream(@"wwwroot\images\shoe\" + fileName + ext, FileMode.CreateNew)
                        );
                
                }

                _context.Add(shoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShoeOrginCountry"] = new SelectList(_context.Countries, "CountryID", "CapitalCityName", shoe.ShoeOrginCountry);
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            ViewData["ShoeOrginCountry"] = new SelectList(_context.Countries, "CountryID", "CapitalCityName", shoe.ShoeOrginCountry);
            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ShoeID,ShoeName,ShoeColor,ShoeOrginCountry")] Shoe shoe)
        {
            if (id != shoe.ShoeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeExists(shoe.ShoeID))
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
            ViewData["ShoeOrginCountry"] = new SelectList(_context.Countries, "CountryID", "CapitalCityName", shoe.ShoeOrginCountry);
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .Include(s => s.Country)
                .FirstOrDefaultAsync(m => m.ShoeID == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoes.Any(e => e.ShoeID == id);
        }
    }
}
