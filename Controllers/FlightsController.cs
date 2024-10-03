using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetTravelDb.Data;
using PetTravelDb.Models;

namespace PetTravelDb.Controllers
{
    public class FlightsController : Controller
    {
        private readonly PetTravelDbContext _context;

        public FlightsController(PetTravelDbContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var petTravelDbContext = _context.Flights.Include(f => f.Airline);
            return View(await petTravelDbContext.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flights = await _context.Flights
                .Include(f => f.Airline)
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
            ViewData["AirlinesId"] = new SelectList(_context.Airlines, "AirlinesId", "AirlinesDescription");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightsId,FlightNumber,BookingRefNo,FlightDate,DepartureTime,ArrivalTime,Origin,Destination,PetId,PetName,Status,AirlinesId")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlinesId"] = new SelectList(_context.Airlines, "AirlinesId", "AirlinesDescription", flights.AirlinesId);
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
            ViewData["AirlinesId"] = new SelectList(_context.Airlines, "AirlinesId", "AirlinesDescription", flights.AirlinesId);
            return View(flights);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightsId,FlightNumber,BookingRefNo,FlightDate,DepartureTime,ArrivalTime,Origin,Destination,PetId,PetName,Status,AirlinesId")] Flights flights)
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
            ViewData["AirlinesId"] = new SelectList(_context.Airlines, "AirlinesId", "AirlinesDescription", flights.AirlinesId);
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
                .Include(f => f.Airline)
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
