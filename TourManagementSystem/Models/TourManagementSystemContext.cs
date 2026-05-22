using Microsoft.EntityFrameworkCore;

namespace TourManagementSystem.Models
{
    // Main database context for the Tour Management System
    public class TourManagementSystemContext : DbContext
    {
        // Constructor for dependency injection
        public TourManagementSystemContext(
            DbContextOptions<TourManagementSystemContext> options)
            : base(options)
        {
        }

        // Table containing all tours
        public DbSet<Tour> Tour { get; set; } = default!;
    }
}