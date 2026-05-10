using Microsoft.AspNetCore.Mvc;

namespace SaigonRideProject.Controllers
{
    public class AdminSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
