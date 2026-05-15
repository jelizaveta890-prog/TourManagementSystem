using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TourManagementSystem.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            // See rida salvestab keelevaliku brauseri küpsisesse (Cookie)
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    Path = "/"
                }
            );

            // Pärast keele salvestamist saadab see kasutaja tagasi samale lehele, kus ta oli
            return LocalRedirect(returnUrl);
        }
    }
}