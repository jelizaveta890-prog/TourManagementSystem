using Microsoft.EntityFrameworkCore;
using TourManagementSystem.Models;

public class TourManagementSystemContext(DbContextOptions<TourManagementSystemContext> options) : DbContext(options)
{
    public TourManagementSystemContext(DbContextOptions<TourManagementSystemContext> options, bool AutoCreate = true) : this(options)
    {
        // delete and recreate the database on startup for testing purposes
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<TourManagementSystem.Models.Tour> Tour { get; set; } = default!;
}