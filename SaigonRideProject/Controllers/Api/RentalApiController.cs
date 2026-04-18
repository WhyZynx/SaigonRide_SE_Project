using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Services;

namespace SaigonRideProject.Controllers.Api
{
    [Route("api/rental")]
    [ApiController]
    public class RentalApiController : ControllerBase
    {
        private readonly RentalService _rentalService;

        public RentalApiController(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("create")]
        public IActionResult Create(int userId, int vehicleId, int stationId)
        {
            var rental = _rentalService.StartRental(userId, vehicleId, stationId);
            return Ok(rental);
        }

        [HttpPost("complete")]
        public IActionResult Complete(int rentalId, int returnStationId)
        {
            var fare = _rentalService.EndRental(rentalId, returnStationId);
            return Ok(new { fare });
        }

        //[HttpPost("pay")]
        //public IActionResult Pay(int rentalId)
        //{
        //    var result = _rentalService.Pay(rentalId);
        //    return Ok(new { success = result });
        //}
    }
}