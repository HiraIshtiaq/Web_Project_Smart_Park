using Smart_Park_D2.Data;

namespace Smart_Park_D2.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int ParkingLocationId { get; set; }
        public string ParkingLocationName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerEmail { get; set; } = string.Empty;

        public string SlotNumber { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; } = "Confirmed";

        public ApplicationUser User { get; set; } = null!;

        public ParkingLocation ParkingLocation { get; set; } = null!;

    }
}
