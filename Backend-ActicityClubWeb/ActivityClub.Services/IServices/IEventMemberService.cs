using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
namespace ActivityClub.Services.IServices
{
    public interface IEventMemberService //: IService<Admin>
    {
        // Add any additional methods specific to AdminService here if needed

        Task<IEnumerable<EventMember>> GetAllAsync();
        Task<EventMember> GetByIdAsync(int id);
        Task AddAsync(EventMember entity);
        Task UpdateAsync(EventMember entity);
        Task DeleteAsync(int id);
        Task<List<MemberDTO>?> GetEventMembers(int eventId);
    
        
    }
}
