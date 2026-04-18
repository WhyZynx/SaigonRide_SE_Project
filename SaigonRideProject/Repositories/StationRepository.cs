using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Models;

namespace SaigonRideProject.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly AppDbContext _context;

        public StationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Station> GetAll()
        {
            return _context.Stations.ToList();
        }

        public Station GetById(int id)
        {
            return _context.Stations
                .Include(s => s.Vehicles)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}