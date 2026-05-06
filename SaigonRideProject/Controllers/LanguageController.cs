using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

public class LanguageController : Controller
{
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        var cookieValue = CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(culture)
        );

        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            cookieValue,
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                Path = "/",
                IsEssential = true
            }
        );

        return LocalRedirect(returnUrl ?? "/");
    }
}