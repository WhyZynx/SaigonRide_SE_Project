using SaigonRideProject.Models;

namespace SaigonRideProject.Repositories
{
    public interface IStationRepository
    {
        List<Station> GetAll();
        Station GetById(int id);
    }
}
