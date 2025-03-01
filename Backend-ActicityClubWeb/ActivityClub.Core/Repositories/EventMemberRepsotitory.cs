using System.Collections.Generic;
using System.Threading.Tasks;
using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ActivityClub.Core.Repositories
{
    public class EventMemberRepository (DbContext context) : Repository<EventMember>(context), IEventMemberRepository
    {
        private ActivityClubContext myDbContext => (ActivityClubContext)Context;



        public async Task<List<MemberDTO>?> GetEventMembers(int eventId)
        {
            var eventMembersIds = await myDbContext.EventMembers
                .Where(em => em.Eventid == eventId)
                .Select(em => em.Memberid)
                .ToListAsync();

            var Members = await myDbContext.Members
                .Where(m => eventMembersIds.Contains(m.Memberid))
                .Select(m => new MemberDTO
                {
                    Memberid = m.Memberid,
                    Name = m.Name,
                    Email = m.Email,
                    Password = m.Password,
                    Dateofbirth = m.Dateofbirth,
                    Phonenumber = m.Phonenumber,
                    Roleid = m.Roleid,
                    Profession = m.Profession,
                    Nationality = m.Nationality,

                })
                .ToListAsync();

            return Members;
        }


    }
}
