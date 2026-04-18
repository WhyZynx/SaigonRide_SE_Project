using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Data;

namespace SaigonRideProject.Controllers.Api
{
    [Route("api/stations")]
    [ApiController]
    public class StationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StationApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stations = _context.Stations.ToList();
            return Ok(stations);
        }
    }
}