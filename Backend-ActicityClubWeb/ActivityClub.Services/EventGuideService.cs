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

namespace ActivityClub.Services
{
    // EventService.cs
    public class EventGuideService(IUnitOfWork unitOfWork) : IEventGuideService
    {
        public async Task AddAsync(EventGuide entity)
        {
            try
            {
                await unitOfWork.EventGuides.AddAsync(entity);
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

        public async Task<IEnumerable<EventGuide>> GetAllAsync()
        {
            return (List<EventGuide>)await unitOfWork.EventGuides.GetAllAsync();
        }

        public async Task<EventGuide> GetByIdAsync(int id)
        {
            return await unitOfWork!.EventGuides.GetByIdAsync(id);
        }

        public Task UpdateAsync(EventGuide entity)
        {
            throw new NotImplementedException();
        }
        public async Task<List<GuideDTO>?> GetEventGuides(int eventId)
        {
            return await unitOfWork.EventGuides.GetEventGuides(eventId);
        }

        // Implement any specific methods for Admin if needed
    }
}
