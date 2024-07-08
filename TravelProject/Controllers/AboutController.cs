using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}