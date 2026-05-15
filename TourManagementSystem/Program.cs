using Microsoft.EntityFrameworkCore;
using TourManagementSystem;

var builder = WebApplication.CreateBuilder(args);

// Andmebaasi ühenduse seadistamine
var connectionString = builder.Configuration.GetConnectionString("TourManagementSystemContext")
    ?? throw new InvalidOperationException("Andmebaasi ühendust ei leitud.");

builder.Services.AddDbContext<TourManagementSystemContext>(options =>
    options.UseSqlServer(connectionString));

// Lisame tavalised kontrollerid ja vaated
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Automaatne andmebaasi loomine käivitamisel
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TourManagementSystemContext>();
    context.Database.EnsureCreated();
}

// Veebiserveri põhiblokk
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Vaikimisi suunamine Tours kontrollerile
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tours}/{action=Index}/{id?}");

app.Run();