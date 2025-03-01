using ActivityClub.Core;
using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityClub.Services.IServices;
using ActivityClub.Core.Repositories.IRepositories;
using ActivityClub.Core.DTOs;
using ActivityClub.Services.IServices;
using ActivityClub.Core.Repositories;

namespace ActivityClub.Services
{
    // EventService.cs
    public class EventMemberService(IUnitOfWork unitOfWork) : IEventMemberService
    {
        public async Task AddAsync(EventMember entity)
        {
            try
            {
                await unitOfWork.EventMembers.AddAsync(entity);
                await unitOfWork.SaveChangesAsync();
                //   return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //  return null;
            }

            //throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventMember>> GetAllAsync()
        {
            return (List<EventMember>)await unitOfWork.EventMembers.GetAllAsync();
        }

        public async Task<EventMember> GetByIdAsync(int id)
        {
            return await unitOfWork!.EventMembers.GetByIdAsync(id);
        }

        public Task UpdateAsync(EventMember entity)
        {
            throw new NotImplementedException();
        }


        public async Task<List<MemberDTO>?> GetEventMembers(int eventId)
        {
            return await unitOfWork.EventMembers.GetEventMembers(eventId);
        }

        // Implement any specific methods for Admin if needed
    }
}
