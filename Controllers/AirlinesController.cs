using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetTravelDb.Data;
using PetTravelDb.Data.Migrations;
using PetTravelDb.Models;

namespace PetTravelDb.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirlinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var AirlineSearch = from s in _context.Airlines
                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                AirlineSearch = AirlineSearch.Where(s => s.AirlinesName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    AirlineSearch = AirlineSearch.OrderByDescending(s => s.AirlinesName);
                    break;
                case "AirlineID":
                    AirlineSearch = AirlineSearch.OrderBy(s => s.AirlinesDescription);
                    break;
                case "date_desc":
                    AirlineSearch = AirlineSearch.OrderByDescending(s => s.AirlinesId);
                    break;





            }

            return View(await AirlineSearch.AsNoTracking().ToListAsync());
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airlines = await _context.Airlines
                .FirstOrDefaultAsync(m => m.AirlinesId == id);
            if (airlines == null)
            {
                return NotFound();
            }

            return View(airlines);
        }

        // GET: Airlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlinesId,AirlinesName,AirlinesDescription")] Models.Airlines airlines)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(airlines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airlines);
        }

        // GET: Airlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airlines = await _context.Airlines.FindAsync(id);
            if (airlines == null)
            {
                return NotFound();
            }
            return View(airlines);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("AirlinesId,AirlinesName,AirlinesDescription")] UpdatedAirlines airlines)
        { 
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(airlines);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if(_context.Airlines == null)
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
                return View(airlines);
            }

            return NotFound();
        }

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airlines = await _context.Airlines
                .FirstOrDefaultAsync(m => m.AirlinesId== id);
            if (airlines == null)
            {
                return NotFound();
            }

            return View(airlines);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airlines = await _context.Airlines.FindAsync(id);
            if (airlines != null)
            {
                _context.Airlines.Remove(airlines);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlinesExists(int id)
        {
            return _context.Airlines.Any(e => e.AirlinesId == id);
        }
    }
}
