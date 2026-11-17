namespace Smart_Park_D2.Models.ViewModels
{
    public class UserDashboardViewModel
    {
        public List<ParkingLocation> ParkingLocations { get; set; } = new List<ParkingLocation>();

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public int ActiveBookings { get; set; }

        public int TotalBookings { get; set; }

        public decimal TotalSpent { get; set; }

        public string CustomerName { get; set; } = string.Empty;
    }
}