using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IEventGuideService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<EventGuide>> GetAllAsync();
        Task<EventGuide> GetByIdAsync(int id);
        Task AddAsync(EventGuide entity);
        Task UpdateAsync(EventGuide entity);
        Task DeleteAsync(int id);
        Task<List<GuideDTO>?> GetEventGuides(int eventId);
    }
}

