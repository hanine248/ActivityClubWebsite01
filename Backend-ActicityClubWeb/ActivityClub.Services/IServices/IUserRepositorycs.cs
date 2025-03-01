using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IUserService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User entity );
        Task UpdateAsync(User entity);
        Task RemoveAsync(int id);
       // Task<IEnumerable<Event>> GetUserEventsAsync(int userId);
    }
}