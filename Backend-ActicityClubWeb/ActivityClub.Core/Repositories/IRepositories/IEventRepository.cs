using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.Repositories.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
       // Task<List<EventDTO>> GetEventByUser(int UserId);
        // Task<List<EventDTO>> GetEventsByUserIdAsync(int userId);
    }
}
