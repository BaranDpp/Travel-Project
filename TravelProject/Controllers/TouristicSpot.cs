using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelProject.Models;
using System.Linq;
using TravelProject.Models.Context;
using Microsoft.AspNetCore.Authorization;

namespace TravelProject.Controllers
{
    public class TouristSpotController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TouristSpotController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var touristSpot = _context.TouristSpots
                .FirstOrDefault(ts => ts.TouristSpotId == id);

            if (touristSpot == null)
            {
                return NotFound();
            }

            return View(touristSpot);
        }
    }
}