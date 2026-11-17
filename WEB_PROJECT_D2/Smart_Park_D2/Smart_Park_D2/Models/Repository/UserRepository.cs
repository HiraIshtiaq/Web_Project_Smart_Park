using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Smart_Park_D2.Data;
using Smart_Park_D2.Models.Interfaces;

namespace Smart_Park_D2.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
