using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetTravelDb.Data;
using PetTravelDb.Models;



namespace PetTravelDb.Controllers
{
    [Authorize]
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index(string SortOrder , string searchString)
        {
           
            ViewData["NameSortParm"] = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = SortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;


            var flightSearch = from s in _context.Flights
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                flightSearch = flightSearch.Where(s => s.BookingRefNo.Equals(searchString));
            }


            switch (SortOrder)
            {
                case "FlightsID_desc":
                    flightSearch = flightSearch.OrderByDescending(s => s.FlightsId);
                    break;
                case "Origin_desc":
                   flightSearch = flightSearch.OrderBy(s => s.Origin);
                    break;
                case "Dest_dsec":
                    flightSearch = flightSearch.OrderByDescending(s => s.Destination);
                    break;
                case "PetID":
                    flightSearch = flightSearch.OrderByDescending(s => s.PetID);
                    break;
                case "PetName_desc":
                    flightSearch = flightSearch.OrderByDescending(s => s.PetName);
                    break;


            }
            return View(await flightSearch.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> FlightSearch(string Flight) 
        {
            var searchFlight = _context.Flights.Where(F => F.BookingRefNo == Flight);
            return View("Index", await searchFlight.ToListAsync());
        }





        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightsId,Origin,Destination,PetID,PetName,BookingRefNo,Status")] Flights flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightsId,Origin,Destination,PetID,PetName,BookingRefNo,Status")] Flights flight)
        {
            if (id != flight.FlightsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightsExists(flight.FlightsId))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (flight== null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightsExists(int id)
        {
            return _context.Flights.Any(e => e.FlightsId == id);
        }
    }
}
