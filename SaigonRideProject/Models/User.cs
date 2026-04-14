using Microsoft.AspNetCore.Mvc;

namespace SaigonRideProject.Models
{
    public class User : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
