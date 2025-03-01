using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.Repositories.IRepositories
{
    public interface IEventGuideRepository : IRepository<EventGuide>
    {
        Task<List<GuideDTO>?> GetEventGuides(int eventId);
    }
}
