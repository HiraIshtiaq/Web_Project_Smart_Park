using Smart_Park_D2.Models;
namespace Smart_Park_D2.Models.Interfaces
{
    public interface IParkingLocationRepository
    {
        Task<List<ParkingLocation>> GetAllAsync();
    }
}