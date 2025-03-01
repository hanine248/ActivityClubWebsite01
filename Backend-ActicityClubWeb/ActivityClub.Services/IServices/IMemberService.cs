using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IMemberService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member> GetByIdAsync(int id);
        Task AddAsync(Member entity);
        Task UpdateAsync(Member entity);
        Task DeleteAsync(int id);
    }
}