using Smart_Park_D2.Data;

namespace Smart_Park_D2.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public List<ParkingLocation> ParkingLocations { get; set; } = new List<ParkingLocation>();

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public int TotalBookings { get; set; }

        public int AvailableSlots { get; set; }

        public int OccupiedSlots { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
