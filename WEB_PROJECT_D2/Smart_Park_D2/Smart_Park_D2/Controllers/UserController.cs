using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smart_Park_D2.Data;
using Smart_Park_D2.Models.Interfaces;
using Smart_Park_D2.Models.ViewModels;
using System.Security.Claims;

namespace Smart_Park_Project.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private IParkingLocationRepository _parkingRepository;
        private IBookingRepository _bookingRepository;
        private UserManager<ApplicationUser> _userManager;
        public UserController(IParkingLocationRepository parkingRepository,IBookingRepository bookingRepository,UserManager<ApplicationUser> userManager)
        {
            _parkingRepository = parkingRepository;
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var locations = await _parkingRepository.GetAllAsync();
            var bookings = await _bookingRepository.GetUserBookingsAsync(userId!);
            var currentUser = await _userManager.GetUserAsync(User);
            int activeBookings = 0;
            int totalBookings = 0;
            decimal totalSpent = 0;
            foreach (var booking in bookings)
            {
                totalBookings++;
                if (booking.Status == "Confirmed")
                {
                    activeBookings++;
                }
                totalSpent += booking.Amount;
            }
            var model = new UserDashboardViewModel
            {
                CustomerName = currentUser?.FullName ?? "Customer",
                ParkingLocations = locations,
                Bookings = bookings,
                ActiveBookings = activeBookings,
                TotalBookings = totalBookings,
                TotalSpent = totalSpent
            };
            return View(model);
        }
    }
}