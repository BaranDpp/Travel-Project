using Microsoft.AspNetCore.Mvc;
using TravelProject.Models;
using System.Linq;
using TravelProject.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace TravelProject.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var city = _context.Cities
                .Include(c => c.TouristSpots)
                .FirstOrDefault(c => c.CityId == id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }
    }
}