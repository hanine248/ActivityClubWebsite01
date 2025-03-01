using System.Collections.Generic;
using System.Threading.Tasks;
using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ActivityClub.Core.Repositories
{
    public class EventGuideRepository(DbContext context) : Repository<EventGuide>(context), IEventGuideRepository
    {
        private ActivityClubContext myDbContext => (ActivityClubContext)Context;
        public async Task<List<GuideDTO>?> GetEventGuides(int eventId)
        {
            var eventGuidesIds = await myDbContext.EventGuides
                .Where(eg => eg.Eventid == eventId)
                .Select(eg => eg.Guideid)
                .ToListAsync();

            var     Guides = await myDbContext.Guides
                .Where(g => eventGuidesIds.Contains(g.Guideid))
                .Select(g => new GuideDTO
                {
                    Guideid = g.Guideid,
                    Name = g.Name,
                    Email = g.Email,
                    Password = g.Password,
                    Dateofbirth = g.Dateofbirth,
                    Phonenumber = g.Phonenumber,
                    Roleid = g.Roleid,
                    Profession = g.Profession,
                    Nationality = g.Nationality,
                    Datejoining = g.Datejoining,
                    EmergencyNumber= g.EmergencyNumber,

            

    })
                .ToListAsync();

            return Guides;
        }

    }
}
