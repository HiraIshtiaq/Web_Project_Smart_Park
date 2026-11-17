using Dapper;
using Microsoft.Data.SqlClient;
using Smart_Park_D2.Models.Interfaces;

namespace Smart_Park_D2.Models.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Smart_Park_D2-ac73dd28-d1d8-44c8-8772-affc81d936b3;Trusted_Connection=True;MultipleActiveResultSets=true";

        public async Task<List<Booking>> GetUserBookingsAsync(string userId)
        {
            using var connection = new SqlConnection(connectionString);

            var query = @"SELECT b.Id, b.UserId, b.ParkingLocationId, b.SlotNumber,b.BookingDate,b.Amount,b.Status,p.Name AS ParkingLocationName
                FROM Bookings b INNER JOIN ParkingLocations p ON b.ParkingLocationId = p.Id WHERE b.UserId = @UserId";
            var bookings = await connection.QueryAsync<Booking>(query, new { UserId = userId });
            return bookings.ToList();
        }
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"SELECT b.Id,b.UserId,b.ParkingLocationId,b.SlotNumber, b.BookingDate, b.Amount, b.Status, p.Name AS ParkingLocationName,u.FullName AS CustomerName,
                u.Email AS CustomerEmail FROM Bookings b
                INNER JOIN ParkingLocations p ON b.ParkingLocationId = p.Id
                INNER JOIN AspNetUsers u ON b.UserId = u.Id
                ORDER BY b.Id DESC";
            var bookings = await connection.QueryAsync<Booking>(query);
            return bookings.ToList();
        }
    }

}
