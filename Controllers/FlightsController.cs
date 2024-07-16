using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetTravelDb.Data;
using PetTravelDb.Models;



namespace PetTravelDb.Controllers
{
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
                case "FlightId_desc":
                    flightSearch = flightSearch.OrderByDescending(s => s.FlightsId);
                    break;
                case "Origin_desc":
                   flightSearch = flightSearch.OrderBy(s => s.Origin);
                    break;
                case "Dest_dsec":
                    flightSearch = flightSearch.OrderByDescending(s => s.Destination);
                    break;
                case "AnimalID":
                    flightSearch = flightSearch.OrderByDescending(s => s.PetID);
                    break;
                case "AnimalName_desc":
                    flightSearch = flightSearch.OrderByDescending(s => s.PetName);
                    break;


            }
            return View(await flightSearch.ToListAsync());
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

            var flights = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
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
        public async Task<IActionResult> Create([Bind("FlightsId,Origin,Destination,AnimalID,AnimalName,BookingRefNo,Status")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flights);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights.FindAsync(id);
            if (flights == null)
            {
                return NotFound();
            }
            return View(flights);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightsId,Origin,Destination,AnimalID,AnimalName,BookingRefNo,Status")] Flights flights)
        {
            if (id != flights.FlightsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightsExists(flights.FlightsId))
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
            return View(flights);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightsId == id);
            if (flights == null)
            {
                return NotFound();
            }

            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flights = await _context.Flights.FindAsync(id);
            if (flights != null)
            {
                _context.Flights.Remove(flights);
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
