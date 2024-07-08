using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelProject.Models;
using TravelProject.Models.Context;

namespace TravelProject.Controllers
{
    [Authorize]
    public class TouristSpotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TouristSpotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TouristSpots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TouristSpots.Include(t => t.City);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TouristSpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TouristSpots == null)
            {
                return NotFound();
            }

            var touristSpot = await _context.TouristSpots
                .Include(t => t.City)
                .FirstOrDefaultAsync(m => m.TouristSpotId == id);
            if (touristSpot == null)
            {
                return NotFound();
            }

            return View(touristSpot);
        }

        // GET: TouristSpots/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
            return View();
        }

        // POST: TouristSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TouristSpotId,Name,Description,ImageUrl,CityId")] TouristSpot touristSpot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(touristSpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", touristSpot.CityId);
            return View(touristSpot);
        }

        // GET: TouristSpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TouristSpots == null)
            {
                return NotFound();
            }

            var touristSpot = await _context.TouristSpots.FindAsync(id);
            if (touristSpot == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", touristSpot.CityId);
            return View(touristSpot);
        }

        // POST: TouristSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TouristSpotId,Name,Description,ImageUrl,CityId")] TouristSpot touristSpot)
        {
            if (id != touristSpot.TouristSpotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touristSpot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristSpotExists(touristSpot.TouristSpotId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", touristSpot.CityId);
            return View(touristSpot);
        }

        // GET: TouristSpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TouristSpots == null)
            {
                return NotFound();
            }

            var touristSpot = await _context.TouristSpots
                .Include(t => t.City)
                .FirstOrDefaultAsync(m => m.TouristSpotId == id);
            if (touristSpot == null)
            {
                return NotFound();
            }

            return View(touristSpot);
        }

        // POST: TouristSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TouristSpots == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TouristSpots'  is null.");
            }
            var touristSpot = await _context.TouristSpots.FindAsync(id);
            if (touristSpot != null)
            {
                _context.TouristSpots.Remove(touristSpot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristSpotExists(int id)
        {
            return (_context.TouristSpots?.Any(e => e.TouristSpotId == id)).GetValueOrDefault();
        }
    }
}