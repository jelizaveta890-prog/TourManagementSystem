using Microsoft.EntityFrameworkCore;
using TourManagementSystem;
using TourManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure database connection string
var connectionString = builder.Configuration.GetConnectionString("TourManagementSystemContext")
    ?? throw new InvalidOperationException("Database connection string 'TourManagementSystemContext' not found.");

builder.Services.AddDbContext<TourManagementSystemContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Database reset and 10 dynamic tours seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TourManagementSystemContext>();

    // Force recreate the database to apply all new column structures seamlessly
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    // Populate with 10 global destinations for booking
    context.Tour.AddRange(
        new Tour
        {
            Name = "Romantic Weekend in Paris",
            Destination = "France, Europe",
            Price = 499,
            Description = "Enjoy the view from the Eiffel Tower, walk along the Seine, and taste fresh croissants in cozy local cafes.",
            Emoji = "🗼",
            Rating = 4.9,
            Region = "Europe"
        },
        new Tour
        {
            Name = "Bali Exotic Getaway",
            Destination = "Indonesia, Asia",
            Price = 1250,
            Description = "Relax on pristine beaches, explore ancient jungle temples, and experience world-class surfing and spa retreats.",
            Emoji = "🏝️",
            Rating = 5.0,
            Region = "Asia"
        },
        new Tour
        {
            Name = "Ancient Wonders of Rome",
            Destination = "Italy, Europe",
            Price = 399,
            Description = "Step back in history visiting the majestic Colosseum, the Vatican, and don't forget to make a wish at Trevi Fountain!",
            Emoji = "🏛️",
            Rating = 4.8,
            Region = "Europe"
        },
        new Tour
        {
            Name = "Tokyo Neon & Tradition",
            Destination = "Japan, Asia",
            Price = 1590,
            Description = "Experience the contrast of futuristic Shibuya streets and peaceful Kyoto shrines during the beautiful cherry blossom season.",
            Emoji = "🍣",
            Rating = 4.9,
            Region = "Asia"
        },
        new Tour
        {
            Name = "New York City Explorer",
            Destination = "USA, North America",
            Price = 999,
            Description = "Walk through Central Park, see a stunning Broadway show, and enjoy the breathtaking panoramic view from the Empire State Building.",
            Emoji = "🗽",
            Rating = 4.7,
            Region = "North America"
        },
        new Tour
        {
            Name = "Egyptian Pyramids Adventure",
            Destination = "Egypt, Africa",
            Price = 550,
            Description = "Discover the ancient secrets of Giza Pyramids, ride a camel across the golden desert dunes, and explore the historic Nile river.",
            Emoji = "🐪",
            Rating = 4.5,
            Region = "Africa"
        },
        new Tour
        {
            Name = "Swiss Alps Ski & Relaxation",
            Destination = "Switzerland, Europe",
            Price = 850,
            Description = "Enjoy world-class ski slopes in Zermatt, breathtaking mountain views, and cozy evenings next to a fireplace with Swiss fondue.",
            Emoji = "⛷️",
            Rating = 4.9,
            Region = "Europe"
        },
        new Tour
        {
            Name = "Sydney & Great Barrier Reef",
            Destination = "Australia, Oceania",
            Price = 1890,
            Description = "Visit the iconic Sydney Opera House and snorkel in the world's largest coral reef system filled with exotic marine life.",
            Emoji = "🦘",
            Rating = 4.8,
            Region = "Oceania"
        },
        new Tour
        {
            Name = "Reykjavik Northern Lights",
            Destination = "Iceland, Europe",
            Price = 790,
            Description = "Witness the magical Aurora Borealis, relax in the natural geothermal waters of the Blue Lagoon, and see epic roaring waterfalls.",
            Emoji = "🌌",
            Rating = 4.6,
            Region = "Europe"
        },
        new Tour
        {
            Name = "Amazon Rainforest Expedition",
            Destination = "Brazil, South America",
            Price = 1100,
            Description = "Immerse yourself in deep wild nature, spot exotic birds and jaguars, and cruise down the mighty Amazon river with expert guides.",
            Emoji = "🦜",
            Rating = 4.7,
            Region = "South America"
        }
    );

    context.SaveChanges();
}

// 4. Configure HTTP Request Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 5. Default Route Configuration pointing to Home
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();