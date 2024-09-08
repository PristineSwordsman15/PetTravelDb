using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetTravelDb.Models;
using PetTravelDb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace PetTravelDb.Controllers
{
    [Authorize]
    public class OwnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OwnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Owners
         async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var ownerSearch = from s in _context.Owner
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                ownerSearch = ownerSearch.Where(s => s.FirstName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    ownerSearch = ownerSearch.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    ownerSearch = ownerSearch.OrderBy(s => s.LastName);
                    break;
                case "OwenrId":
                    ownerSearch = ownerSearch.OrderByDescending(s => s.OwnerId);
                    break;



            }

            return View(await ownerSearch.AsNoTracking().ToListAsync());


            // GET: Owners/Details/5
            async Task<IActionResult> Details(int? id)

            {
                if (id == null)
                {
                    return NotFound();
                }

                var owner = await _context.Owner
                    .FirstOrDefaultAsync(m => m.OwnerId == id);
                if (owner == null)
                {
                    return NotFound();
                }

                return View(owner);
            }


            // GET: Owners/Create

             IActionResult Create()
            {
                return View();
            }

            // GET: Owners/Edit/5
            async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var owner = await _context.Owner.FindAsync(id);
                if (owner == null)
                {
                    return NotFound();
                }
                return View(owner);
            }

            // GET: Owners/Delete/5
             async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var owner = await _context.Owner
                    .FirstOrDefaultAsync(m => m.OwnerId == id);
                if (owner == null)
                {
                    return NotFound();
                }

                return View(owner);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> Create(OwnersController @this, [Bind(new[] { "OwnerId,FirstName,LastName,FlightId,PhoneNumber,BookingRefNo,EmailAddress,Age" })] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(owner);
                await @this._context.SaveChangesAsync();
                return @this.RedirectToAction(nameof(@this.Index));
            }
            return View(owner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> Edit(int id, [Bind(new[] { "OwnerId,FirstName,LastName,FlightId,PhoneNumber,BookingRefNo,EmailAddress,Age" })] Owner owner)
        {
            if (id != owner.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.OwnerExists == null)
                    {
                        throw;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owner.FindAsync(id);
            if (owner != null)
            {
                _context.Owner.Remove(owner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _context.Owner.Any(e => e.OwnerId == id);
        }
    }
}
