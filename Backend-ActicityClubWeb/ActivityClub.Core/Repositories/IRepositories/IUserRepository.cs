using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ActivityClub.Core.Models;


namespace ActivityClub.Core.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        //public async Task AddAsync(User entity, int roleid);
        // Add any Admin-specific methods here
        //Task<IEnumerable<Admin>> GetAdminsByRoleAsync(int roleId);
       // Task<IEnumerable<Event>> GetUserEventsAsync(int userId);
        //Task<IEnumerable<Admin>> GetAdmminsAsync();
    }
}
