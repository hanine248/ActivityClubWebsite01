using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using ActivityClub.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;
using ActivityClub.Services.IServices;
using ActivityClub.Services;
using Microsoft.AspNetCore.Authorization;

namespace ActivityClub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService; // Use IService<Admin>
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetEvents()
        {
            try
            {
                var events = await _eventService.GetAllAsync();
                var eventDtos = _mapper.Map<IEnumerable<EventDTO>>(events);
                return Ok(eventDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(int id)
        {
            var events = await _eventService.GetByIdAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            var eventDto = _mapper.Map<EventDTO>(events);
            return Ok(eventDto);
        }

        // POST: api/Event
        [HttpPost]
        public async Task<ActionResult<EventDTO>> PostEvent(EventDTO eventDto)
        {
            var events = _mapper.Map<Event>(eventDto);
            await _eventService.AddAsync(events);
            var createdEventDto = _mapper.Map<EventDTO>(events);
            return CreatedAtAction(nameof(GetEvent), new { id = createdEventDto.Eventid }, createdEventDto);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventDTO eventDto)
        {
            if (id != eventDto.Eventid)
            {
                return BadRequest();
            }

            var events = _mapper.Map<Event>(eventDto);
            await _eventService.UpdateAsync(events);

            return NoContent();
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var events = await _eventService.GetByIdAsync(id);
            if (events == null)
            {
                return NotFound();
            }

            await _eventService.DeleteAsync(id);

            return NoContent();
        }
       // [HttpGet("user/{userId}/events")]
        //public async Task<ActionResult<List<EventDTO>>> GetEventsByUserId(int userId)
        //{
          //  var events = await _eventService.GetEventByUser(userId);

            //if (events == null || !events.Any())
            //{
              //  return NotFound($"No events found for user with ID {userId}.");
            //}

            //return Ok(events);
        //}
    }
    }