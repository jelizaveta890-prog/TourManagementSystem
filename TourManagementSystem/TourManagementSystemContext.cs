using Microsoft.EntityFrameworkCore;

public class TourManagementSystemContext(DbContextOptions<TourManagementSystemContext> options) : DbContext(options)
{
    public DbSet<TourManagementSystem.Models.Tour> Tour { get; set; } = default!;
}
