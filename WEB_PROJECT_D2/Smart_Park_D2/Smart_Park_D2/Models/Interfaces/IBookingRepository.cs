namespace Smart_Park_D2.Models.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetUserBookingsAsync(string userId);
        Task<List<Booking>> GetAllBookingsAsync();
    }
}
