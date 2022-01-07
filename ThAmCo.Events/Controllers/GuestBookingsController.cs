using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class GuestBookingsController : Controller
    {
        private readonly EventContext _context;

        public GuestBookingsController(EventContext context)
        {
            _context = context;
        }

        // GET: GuestBookings
        public async Task<IActionResult> Index()
        {
            var eventContext = _context.GuestBooking.Include(g => g.Customer).Include(g => g.Event);
            return View(await eventContext.ToListAsync());
        }

        // GET: GuestBookings/Details/5
        public async Task<IActionResult> Details(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBooking
                .Include(g => g.Customer)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.CustomerId == id1 && m.EventId == id2);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // GET: GuestBookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle");
            return View();
        }

        // POST: GuestBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,EventId")] GuestBooking guestBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
            return View(guestBooking);
        }

        // GET: GuestBookings/Edit/5
        public async Task<IActionResult> Edit(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBooking
                .Include(g => g.Customer)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.CustomerId == id1 && m.EventId == id2);
            if (guestBooking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
            return View(guestBooking);
        }

        // POST: GuestBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,EventId")] GuestBooking guestBooking)
        {
            if (id != guestBooking.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestBookingExists(guestBooking.CustomerId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventTitle", guestBooking.EventId);
            return View(guestBooking);
        }

        // GET: GuestBookings/Delete/5
        public async Task<IActionResult> Delete(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBooking
                .Include(g => g.Customer)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.CustomerId == id1 && m.EventId == id2);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // POST: GuestBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind ("EventId")] GuestBooking b)
        {
            var guestBooking = await _context.GuestBooking.FindAsync(id, b.EventId);
            _context.GuestBooking.Remove(guestBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestBookingExists(int id)
        {
            return _context.GuestBooking.Any(e => e.CustomerId == id);
        }
    }
}
