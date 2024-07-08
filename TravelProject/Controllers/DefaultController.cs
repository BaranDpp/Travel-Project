using Microsoft.AspNetCore.Mvc;
using TravelProject.Models.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DefaultController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _context.Cities.ToListAsync();
            return View(cities);
        }
    }
}