using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IAdminService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int id);
        Task AddAsync(Admin entity);
        Task UpdateAsync(Admin entity);
        Task DeleteAsync(int id);
    }
}