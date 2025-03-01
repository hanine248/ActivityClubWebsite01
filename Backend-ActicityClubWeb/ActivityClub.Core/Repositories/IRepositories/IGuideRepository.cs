using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.Repositories.IRepositories
{
    public interface IGuideRepository : IRepository<Guide>
    {
        // Add any Admin-specific methods here
        //Task<IEnumerable<Admin>> GetAdminsByRoleAsync(int roleId);

        //Task<IEnumerable<Admin>> GetAdmminsAsync();
    }
}
