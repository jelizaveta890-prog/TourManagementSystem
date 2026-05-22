using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagementSystem.Models;

namespace TourManagementSystem.Controllers
{
    // Controller responsible for all tour operations
    public class ToursController : Controller
    {
        private readonly TourManagementSystemContext _context;

        // Constructor with dependency injection
        public ToursController(TourManagementSystemContext context)
        {
            _context = context;
        }


        // =====================================================
        // Display all tours
        // =====================================================
        public async Task<IActionResult> Index()
        {
            var tours = await _context.Tour.ToListAsync();

            return View(tours ?? new List<Tour>());
        }


        // =====================================================
        // Display single tour details
        // =====================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tour
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }


        // =====================================================
        // Open create page
        // =====================================================
        public IActionResult Create()
        {
            return View();
        }


        // =====================================================
        // Create new tour
        // =====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Destination,Price,Description")] Tour tour)
        {
            // Add default values manually
            tour.Emoji = "✈️";
            tour.Region = "Europe";
            tour.Rating = 5.0;
            tour.DurationDays = 7;
            tour.RewiewCount = 0;

            // Validate form
            if (ModelState.IsValid)
            {
                // Add tour to database
                _context.Add(tour);

                // Save changes
                await _context.SaveChangesAsync();

                // Return to catalog
                return RedirectToAction(nameof(Index));
            }

            return View(tour);
        }


        // =====================================================
        // Open edit page
        // =====================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tour.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }


        // =====================================================
        // Update existing tour
        // =====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int? id,
            [Bind("Id,Name,Destination,Price,Description,Emoji,DurationDays,Region,Rating,RewiewCount")]
            Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(tour);
        }


        // =====================================================
        // Open delete confirmation page
        // =====================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tour
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }


        // =====================================================
        // Delete tour from database
        // =====================================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tour = await _context.Tour.FindAsync(id);

            if (tour != null)
            {
                _context.Tour.Remove(tour);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // =====================================================
        // Check if tour exists
        // =====================================================
        private bool TourExists(int? id)
        {
            return _context.Tour.Any(e => e.Id == id);
        }
    }
}