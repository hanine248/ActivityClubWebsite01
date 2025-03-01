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
using AutoMapper;

namespace ActivityClub.Services
{
    // EventService.cs
    public class EventService(IUnitOfWork unitOfWork) : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public async Task AddAsync(Event entity)
        {
            try
            {
                await unitOfWork.Events.AddAsync(entity);
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

        public async Task DeleteAsync(int id)
        {
            try
            {
                var eventToDelete = await unitOfWork.Events.GetByIdAsync(id);
                if (eventToDelete != null)
                {
                    await unitOfWork.Events.RemoveAsync(eventToDelete);
                    await unitOfWork.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where the event with the specified ID does not exist
                    Console.WriteLine("Event not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Handle or log the exception as needed
            }
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return (List<Event>)await unitOfWork.Events.GetAllAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await unitOfWork!.Events.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Event entity)
        {
            try
            {
                await unitOfWork.Events.UpdateAsync(entity);
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Handle or log the exception as needed
            }
        }
        // public async Task<List<EventDTO>> GetEventByUser(int userId)

        //     var events = await _eventRepository.GetEventByUser(userId);
        //  var eventDtos = _mapper.Map<List<EventDTO>>(events);  // Map to DTOs asynchronously
        //  //   return eventDtos;
        // }


        // Implement any specific methods for Admin if needed
    }
}
