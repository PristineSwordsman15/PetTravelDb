using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetTravelDb.Data;
using PetTravelDb.Models;

namespace PetTravelDb.Controllers
{
    [Authorize]
    public class AirlinesController : Controller
    {
        private readonly PetTravelDbContext _context;

        public AirlinesController(PetTravelDbContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airlines.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("AirlinesId,AirlinesName,AirlinesDescription")] Airlines airlines)
        {
            if (ModelState.IsValid)
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
        public async Task<IActionResult> Edit(int id, [Bind("AirlinesId,AirlinesName,AirlinesDescription")] Airlines airlines)
        {
            if (id != airlines.AirlinesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airlines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlinesExists(airlines.AirlinesId))
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

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
