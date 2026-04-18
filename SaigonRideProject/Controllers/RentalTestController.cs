using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Services;

public class RentalTestController : Controller
{
    private readonly RentalService _service;

    public IActionResult Index()
    {
        return Content("RentalTest is working");
    }

    public RentalTestController(RentalService service)
    {
        _service = service;
    }

    public IActionResult Create()
    {
        var rental = _service.Create(1, 2, 1);
        return Json(rental);
    }

    public IActionResult Complete(int id)
    {
        var fare = _service.Complete(id, 2);
        return Json(new { fare });
    }
}