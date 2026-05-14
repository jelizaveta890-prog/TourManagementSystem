using Microsoft.EntityFrameworkCore;
using TourManagementSystem;

var builder = WebApplication.CreateBuilder(args);

// 1. Andmebaasi seadistamine
var connectionString = builder.Configuration.GetConnectionString("TourManagementSystemContext")
    ?? throw new InvalidOperationException("Connection string 'TourManagementSystemContext' not found.");

builder.Services.AddDbContext<TourManagementSystemContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Teenuste lisamine
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. AUTOMAATNE ANDMEBAASI LOOMINE (Sinu lisatud osa, nüüd parandatud)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Eemaldasime siit vahelt ".Data"
        var context = services.GetRequiredService<TourManagementSystemContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Andmebaasi viga: " + ex.Message);
    }
}

// 4. Veebiserveri seadistamine
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();