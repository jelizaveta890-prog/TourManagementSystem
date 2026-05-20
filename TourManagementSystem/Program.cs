using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TourManagementSystem.Models;

namespace TourManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // Injecting the database context to access our tours
        private readonly TourManagementSystemContext _context;

        public HomeController(TourManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            // C# Logic: Fetch top 3 highest-rated tours from SQL Server for the home showcase
            var popularTours = await _context.Tour
                .OrderByDescending(t => t.Rating)
                .Take(3)
                .ToListAsync();

            // Pass the dynamic list straight to the View
            return View(popularTours);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}