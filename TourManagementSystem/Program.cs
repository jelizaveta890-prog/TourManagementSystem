using Microsoft.EntityFrameworkCore;
using TourManagementSystem;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// 1. Andmebaasi seadistamine
var connectionString = builder.Configuration.GetConnectionString("TourManagementSystemContext")
    ?? throw new InvalidOperationException("Connection string 'TourManagementSystemContext' not found.");

builder.Services.AddDbContext<TourManagementSystemContext>(options =>
    options.UseSqlServer(connectionString));

// 2. KEELTE SEADISTAMINE (Lokaliseerimine)
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Määrame toetatud keeled, 'en' on esimene (vaikevalik)
    var supportedCultures = new[] {
        new CultureInfo("en"),
        new CultureInfo("et"),
        new CultureInfo("ru")
    };

    options.DefaultRequestCulture = new RequestCulture("en"); // Alustab alati inglise keeles
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // EEMALDAME kõik muud pakkujad (nagu brauseri seaded) 
    // ja jätame AINULT küpsise (Cookie), et sinu valik jääks püsima.
    options.RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(new CookieRequestCultureProvider());
});

var app = builder.Build();

// 3. AUTOMAATNE ANDMEBAASI LOOMINE
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
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
app.UseStaticFiles(); // Lisame kindluse mõttes ka selle
app.UseRouting();

// AKTIVEERI KEELTE KASUTAMINE (peab olema enne Authorizationit)
app.UseRequestLocalization();

app.UseAuthorization();
app.MapStaticAssets();

// 5. MARSRUUTIMINE (Suunab kohe Tours lehele)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tours}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();