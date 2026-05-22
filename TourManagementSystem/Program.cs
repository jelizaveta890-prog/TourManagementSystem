using Microsoft.EntityFrameworkCore;
using TourManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);


// =====================================================
// Configure database connection
// =====================================================

var connectionString = builder.Configuration
    .GetConnectionString("TourManagementSystemContext")
    ?? throw new InvalidOperationException(
        "Database connection string 'TourManagementSystemContext' was not found.");


builder.Services.AddDbContext<TourManagementSystemContext>(options =>
    options.UseSqlServer(connectionString));


// =====================================================
// Register MVC services
// =====================================================

builder.Services.AddControllersWithViews();

var app = builder.Build();


// =====================================================
// Create database and seed starter tours
// =====================================================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Get database context instance
    var context = services.GetRequiredService<TourManagementSystemContext>();


    // Automatically create database if it does not exist
    context.Database.EnsureCreated();


    // Seed tours only if database is empty
    if (!context.Tour.Any())
    {
        context.Tour.AddRange(

            // Paris Tour
            new Tour
            {
                Name = "Romantic Weekend in Paris",
                Destination = "France, Europe",
                Price = 499,
                Description = "Enjoy the Eiffel Tower, French cafes, and romantic evening walks.",
                Emoji = "🗼",
                Rating = 4.9,
                Region = "Europe"
            },

            // Bali Tour
            new Tour
            {
                Name = "Bali Exotic Getaway",
                Destination = "Indonesia, Asia",
                Price = 1250,
                Description = "Relax on tropical beaches and explore beautiful jungle temples.",
                Emoji = "🏝️",
                Rating = 5.0,
                Region = "Asia"
            },

            // Rome Tour
            new Tour
            {
                Name = "Ancient Wonders of Rome",
                Destination = "Italy, Europe",
                Price = 399,
                Description = "Visit the Colosseum, Vatican City, and famous Italian landmarks.",
                Emoji = "🏛️",
                Rating = 4.8,
                Region = "Europe"
            },

            // Tokyo Tour
            new Tour
            {
                Name = "Tokyo Neon & Tradition",
                Destination = "Japan, Asia",
                Price = 1590,
                Description = "Discover modern Tokyo and traditional Japanese culture.",
                Emoji = "🍣",
                Rating = 4.9,
                Region = "Asia"
            },

            // New York Tour
            new Tour
            {
                Name = "New York City Explorer",
                Destination = "USA, North America",
                Price = 999,
                Description = "Explore Times Square, Central Park, and Broadway shows.",
                Emoji = "🗽",
                Rating = 4.7,
                Region = "North America"
            },

            // Egypt Tour
            new Tour
            {
                Name = "Egyptian Pyramids Adventure",
                Destination = "Egypt, Africa",
                Price = 550,
                Description = "See the pyramids, ride camels, and explore ancient history.",
                Emoji = "🐪",
                Rating = 4.5,
                Region = "Africa"
            },

            // Switzerland Tour
            new Tour
            {
                Name = "Swiss Alps Ski Resort",
                Destination = "Switzerland, Europe",
                Price = 850,
                Description = "Enjoy skiing and breathtaking mountain landscapes.",
                Emoji = "⛷️",
                Rating = 4.9,
                Region = "Europe"
            },

            // Australia Tour
            new Tour
            {
                Name = "Sydney & Great Barrier Reef",
                Destination = "Australia, Oceania",
                Price = 1890,
                Description = "Visit Sydney Opera House and dive into coral reefs.",
                Emoji = "🦘",
                Rating = 4.8,
                Region = "Oceania"
            },

            // Iceland Tour
            new Tour
            {
                Name = "Reykjavik Northern Lights",
                Destination = "Iceland, Europe",
                Price = 790,
                Description = "Watch the Aurora Borealis and relax in hot springs.",
                Emoji = "🌌",
                Rating = 4.6,
                Region = "Europe"
            },

            // Amazon Tour
            new Tour
            {
                Name = "Amazon Rainforest Expedition",
                Destination = "Brazil, South America",
                Price = 1100,
                Description = "Explore rainforest wildlife and river adventures.",
                Emoji = "🦜",
                Rating = 4.7,
                Region = "South America"
            }
        );

        // Save starter tours to database
        context.SaveChanges();
    }
}


// =====================================================
// Configure HTTP request pipeline
// =====================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// =====================================================
// Configure application routes
// =====================================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();