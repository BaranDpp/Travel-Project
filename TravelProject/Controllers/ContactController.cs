using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
