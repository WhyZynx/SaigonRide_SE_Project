using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers.Api
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehicleApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            var vehicles = _context.Vehicles
                .Where(v => v.Status == "Available")
                .ToList();

            return Ok(vehicles);
        }

        [HttpGet("by-station")]
        public IActionResult GetByStation(int stationId)
        {
            var vehicles = _context.Vehicles
                .Where(v => v.Status == "Available" && v.StationId == stationId)
                .ToList();

            return Ok(vehicles);
        }
    }
}