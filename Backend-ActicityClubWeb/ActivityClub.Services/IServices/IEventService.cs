using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IEventService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task AddAsync(Event entity);
        Task UpdateAsync(Event entity);
        Task DeleteAsync(int id);
      //  Task<List<EventDTO>> GetEventByUser(int UserId);
    }
}