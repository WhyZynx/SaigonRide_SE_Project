using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Services.Pricing;

namespace SaigonRideProject.Controllers
{
    public class PricingController : Controller
    {
        private readonly IPricingStrategy _pricing;

        public PricingController(IPricingStrategy pricing)
        {
            _pricing = pricing;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}