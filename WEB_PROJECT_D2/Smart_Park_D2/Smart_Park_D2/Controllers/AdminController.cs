using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smart_Park_D2.Models.Interfaces;
using Smart_Park_D2.Models.ViewModels;
namespace Smart_Park_Project.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IUserRepository _userRepository;
        private IParkingLocationRepository _parkingLocationRepository;
        private IBookingRepository _bookingRepository;
        public AdminController(IUserRepository userRepository, IParkingLocationRepository parkingLocationRepository,IBookingRepository bookingRepository)
        {
            _userRepository = userRepository;
            _parkingLocationRepository = parkingLocationRepository;
            _bookingRepository = bookingRepository;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var parkingLocations = await _parkingLocationRepository.GetAllAsync();
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            int availableSlots = 0;
            int occupiedSlots = 0;
            decimal totalRevenue = 0;
            foreach (var location in parkingLocations)
            {
                availableSlots += location.TotalSlots - location.OccupiedSlots;

                occupiedSlots += location.OccupiedSlots;
            }
            foreach (var booking in bookings)
            {
                totalRevenue += booking.Amount;
            }
            var viewModel = new AdminDashboardViewModel
            {
                Users = users,
                ParkingLocations = parkingLocations,
                Bookings = bookings,
                TotalBookings = bookings.Count,
                AvailableSlots = availableSlots,
                OccupiedSlots = occupiedSlots,
                TotalRevenue = totalRevenue
            };
            return View(viewModel);
        }
    }
}

