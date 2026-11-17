using Microsoft.Data.SqlClient;
using Dapper;
using Smart_Park_D2.Models.Interfaces;
namespace Smart_Park_D2.Models.Repository
{
    public class ParkingLocationRepository:IParkingLocationRepository
    {
        private string connectionString ="Server=(localdb)\\mssqllocaldb;Database=aspnet-Smart_Park_D2-ac73dd28-d1d8-44c8-8772-affc81d936b3;Trusted_Connection=True;MultipleActiveResultSets=true";
        public async Task<List<ParkingLocation>> GetAllAsync()
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"SELECT Id, Name, Address, RatePerHour,TotalSlots, OccupiedSlots FROM ParkingLocations";
            var locations = await connection.QueryAsync<ParkingLocation>(query);
            return locations.ToList();
        }
    }
}
