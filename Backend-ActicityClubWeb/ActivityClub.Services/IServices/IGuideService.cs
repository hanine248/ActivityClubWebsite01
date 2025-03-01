using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IGuideService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<Guide>> GetAllAsync();
        Task<Guide> GetByIdAsync(int id);
        Task AddAsync(Guide entity);
        Task UpdateAsync(Guide entity);
        Task DeleteAsync(int id);
    }
}