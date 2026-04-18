using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;
using SaigonRideProject.Services;

namespace SaigonRideProject.Controllers
{
    public class RentalController : Controller
    {
        private readonly RentalService _service;

        public RentalController(RentalService service)
        {
            _service = service;
        }

        public IActionResult Create(int userId, int vehicleId, int stationId)
        {
            return Json(_service.Create(userId, vehicleId, stationId));
        }

        public IActionResult Complete(int rentalId, int returnStationId)
        {
            return Json(_service.Complete(rentalId, returnStationId));
        }

        //public IActionResult Pay(int rentalId)
        //{
        //    return Json(_service.Pay(rentalId));
        //}
    }
}