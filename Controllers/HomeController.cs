using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemperatureApi.Data;

namespace TemperatureApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly TemperatureContext _context;

        public HomeController(TemperatureContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var readings = _context.TempHistory.ToList(); // Fetch the data from the database
            return View(readings); // Pass the data to the view
        }
    }
}
