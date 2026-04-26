using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;

public class BaseController : Controller
{
    protected readonly AppDbContext _context;

    public BaseController(AppDbContext context)
    {
        _context = context;
    }

    public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId != null)
        {
            var hasActiveRental = _context.Rentals
                .Any(r => r.UserId == userId && r.Status == "InProgress");

            ViewBag.ActiveRentalId = _context.Rentals
                .Where(r => r.UserId == userId && r.Status == "InProgress")
                .Select(r => r.Id)
                .FirstOrDefault();
            ViewBag.HasActiveRental = hasActiveRental;
        }

        base.OnActionExecuting(context);
    }
}