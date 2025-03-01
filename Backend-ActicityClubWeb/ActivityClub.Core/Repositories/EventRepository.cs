using System.Collections.Generic;
using System.Threading.Tasks;
using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ActivityClub.Core.Repositories
{
    public class EventRepository(DbContext context) : Repository<Event>(context), IEventRepository
    {
        private ActivityClubContext myDbContext => (ActivityClubContext)Context;
        private readonly IMapper _mapper;
       // public async Task<List<EventDTO>> GetEventByUser(int userId)
        
          //  {
            // Retrieve events where the user is a member
          //  var memberEvents = await myDbContext.EventMembers
            //    .Where(em => em.Member.Memberid == userId)
              //  .Select(em => em.Event)
                //.ToListAsync();

            // Retrieve events where the user is a guide
            //var guideEvents = await myDbContext.EventGuides
              //  .Where(eg => eg.Guide.Guideid == userId)
                //.Select(eg => eg.Event)
                //.ToListAsync();


            // Combine both lists of events
            ///var allEvents = memberEvents.Union(guideEvents).ToList();

            // Map to EventDTOs (assuming you have a mapper set up)
           // var eventDtos = _mapper.Map<List<EventDTO>>(allEvents);

          //  return eventDtos;
        //}


    }
}
