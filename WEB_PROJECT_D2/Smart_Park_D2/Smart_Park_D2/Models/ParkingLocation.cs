namespace Smart_Park_D2.Models
{
    public class ParkingLocation
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal RatePerHour { get; set; }

        public int TotalSlots { get; set; }

        public int OccupiedSlots { get; set; }
    }
}
