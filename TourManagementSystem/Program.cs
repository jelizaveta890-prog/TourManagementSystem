using Microsoft.EntityFrameworkCore;
using TourManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);


// ===============================================
// Configure database connection
// ===============================================

var connectionString = builder.Configuration.GetConnectionString("TourManagementSystemContext")
    ?? throw new InvalidOperationException(
        "Database connection string 'TourManagementSystemContext' not found.");

builder.Services.AddDbContext<TourManagementSystemContext>(options =>
    options.UseSqlServer(connectionString));


// ===============================================
// Add MVC services
// ===============================================

builder.Services.AddControllersWithViews();

var app = builder.Build();


// ===============================================
// Create database and seed initial tours
// ===============================================

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TourManagementSystemContext>();


    // Create database automatically if it does not exist
    context.Database.EnsureCreated();


    // Seed default tours only once
    if (!context.Tour.Any())
    {
        context.Tour.AddRange(

            new Tour
            {
                Name = "Romantic Weekend in Paris",
                Destination = "France, Europe",
                Price = 499,
                Description = "Enjoy the Eiffel Tower, fresh croissants, and romantic walks along the Seine river.",
                Emoji = "🗼",
                Rating = 4.9,
                Region = "Europe"
            },

            new Tour
            {
                Name = "Bali Exotic Getaway",
                Destination = "Indonesia, Asia",
                Price = 1250,
                Description = "Relax on tropical beaches and explore ancient jungle temples.",
                Emoji = "🏝️",
                Rating = 5.0,
                Region = "Asia"
            },

            new Tour
            {
                Name = "Ancient Wonders of Rome",
                Destination = "Italy, Europe",
                Price = 399,
                Description = "Visit the Colosseum, Vatican City, and beautiful Roman streets.",
                Emoji = "🏛️",
                Rating = 4.8,
                Region = "Europe"
            },

            new Tour
            {
                Name = "Tokyo Neon & Tradition",
                Destination = "Japan, Asia",
                Price = 1590,
                Description = "Experience modern Tokyo and traditional Japanese culture.",
                Emoji = "🍣",
                Rating = 4.9,
                Region = "Asia"
            },

            new Tour
            {
                Name = "New York City Explorer",
                Destination = "USA, North America",
                Price = 999,
                Description = "Visit Times Square, Central Park, and Broadway shows.",
                Emoji = "🗽",
                Rating = 4.7,
                Region = "North America"
            },

            new Tour
            {
                Name = "Egyptian Pyramids Adventure",
                Destination = "Egypt, Africa",
                Price = 550,
                Description = "Discover ancient pyramids and ride camels in the desert.",
                Emoji = "🐪",
                Rating = 4.5,
                Region = "Africa"
            },

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

            new Tour
            {
                Name = "Sydney & Great Barrier Reef",
                Destination = "Australia, Oceania",
                Price = 1890,
                Description = "Explore Sydney Opera House and dive into coral reefs.",
                Emoji = "🦘",
                Rating = 4.8,
                Region = "Oceania"
            },

            new Tour
            {
                Name = "Reykjavik Northern Lights",
                Destination = "Iceland, Europe",
                Price = 790,
                Description = "Watch the magical Aurora Borealis and visit hot springs.",
                Emoji = "🌌",
                Rating = 4.6,
                Region = "Europe"
            },

            new Tour
            {
                Name = "Amazon Rainforest Expedition",
                Destination = "Brazil, South America",
                Price = 1100,
                Description = "Explore wild rainforest nature and exotic wildlife.",
                Emoji = "🦜",
                Rating = 4.7,
                Region = "South America"
            }
        );

        context.SaveChanges();
    }
}


// ===============================================
// Configure HTTP request pipeline
// ===============================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// ===============================================
// Configure default route
// ===============================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();