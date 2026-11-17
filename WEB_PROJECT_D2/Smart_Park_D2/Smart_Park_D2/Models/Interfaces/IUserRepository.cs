using Smart_Park_D2.Data;

namespace Smart_Park_D2.Models.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<ApplicationUser>> GetAllUsersAsync();
    }
}
