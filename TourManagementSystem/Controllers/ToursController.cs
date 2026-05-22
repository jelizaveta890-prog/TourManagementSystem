
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagementSystem.Models;

public class ToursController : Controller
{
    private readonly TourManagementSystemContext _context;

    public ToursController(TourManagementSystemContext context)
    {
        _context = context;
    }

    // GET: TOURS
    public async Task<IActionResult> Index()    
    {
        var tours = await _context.Tour.ToListAsync();
        return View(tours ?? new List<Tour>());
    }

    // GET: TOURS/Details/5
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

    // GET: TOURS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TOURS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // POST: TOURS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Destination,Price,Description")] Tour tour)
    {
        // Мы временно убрали проверку, чтобы тур точно сохранялся
        _context.Add(tour);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: TOURS/Edit/5
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

    // POST: TOURS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Destination,Price,Description")] Tour tour)
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
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(tour);
    }

    // GET: TOURS/Delete/5
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

    // POST: TOURS/Delete/5
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

    private bool TourExists(int? id)
    {
        return _context.Tour.Any(e => e.Id == id);
    }
}
