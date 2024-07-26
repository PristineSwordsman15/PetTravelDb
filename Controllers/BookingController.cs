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
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        

    // GET: Booking
        

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingProcess = await _context.BookingProcess
                .FirstOrDefaultAsync(m => m.BookingProcessID == id);
            if (bookingProcess == null)
            {
                return NotFound();
            }

            return View(bookingProcess);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] BookingProcess bookingProcess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingProcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingProcess);
        }

        // GET: Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingProcess = await _context.BookingProcess.FindAsync(id);
            if (bookingProcess == null)
            {
                return NotFound();
            }
            return View(bookingProcess);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] BookingProcess bookingProcess)
        {
            if (id != bookingProcess.BookingProcessID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingProcess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingProcessExists(bookingProcess.BookingProcessID))
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
            return View(bookingProcess);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingProcess = await _context.BookingProcess
                .FirstOrDefaultAsync(m => m.BookingProcessID == id);
            if (bookingProcess == null)
            {
                return NotFound();
            }

            return View(bookingProcess);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingProcess = await _context.BookingProcess.FindAsync(id);
            if (bookingProcess != null)
            {
                _context.BookingProcess.Remove(bookingProcess);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingProcessExists(int id)
        {
            return _context.BookingProcess.Any(e => e.BookingProcessID == id);
        }
    }
}
