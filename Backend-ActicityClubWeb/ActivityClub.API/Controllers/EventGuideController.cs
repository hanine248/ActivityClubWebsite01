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
 //   [Authorize]
    public class EventGuideController : ControllerBase
    {
        private readonly IEventGuideService _eventguideService; // Use IService<Admin>
        private readonly IMapper _mapper;

        public EventGuideController(IEventGuideService eventguideService, IMapper mapper)
        {
            _eventguideService = eventguideService;
            _mapper = mapper;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventGuideDTO>>> GetEventGuide()
        {
            try
            {
                var eventguides = await _eventguideService.GetAllAsync();
                var eventguideDtos = _mapper.Map<IEnumerable<EventGuideDTO>>(eventguides);
                return Ok(eventguideDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventGuideDTO>> GetEventGuide(int id)
        {
            var eventguides = await _eventguideService.GetByIdAsync(id);
            if (eventguides == null)
            {
                return NotFound();
            }
            var eventguideDto = _mapper.Map<EventGuideDTO>(eventguides);
            return Ok(eventguideDto);
        }

        // POST: api/EventGuide
        [HttpPost]
        public async Task<ActionResult<EventGuideDTO>> PostEventGuide(EventGuideDTO eventguideDto)
        {
            var eventguides = _mapper.Map<EventGuide>(eventguideDto);
            await _eventguideService.AddAsync(eventguides);
            var createdEventGuideDto = _mapper.Map<EventGuideDTO>(eventguides);
            return CreatedAtAction(nameof(GetEventGuide), new { id = createdEventGuideDto.Eventguideid }, createdEventGuideDto);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventGuide(int id, EventGuideDTO eventguideDto)
        {
            if (id != eventguideDto.Eventguideid)
            {
                return BadRequest();
            }

            var eventguides = _mapper.Map<EventGuide>(eventguideDto);
            await _eventguideService.UpdateAsync(eventguides);

            return NoContent();
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventGuide(int id)
        {
            var eventguides = await _eventguideService.GetByIdAsync(id);
            if (eventguides == null)
            {
                return NotFound();
            }

            await _eventguideService.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("event/{eventId}/Guides")]
        public async Task<ActionResult<List<GuideDTO>>> GetEventGuides(int eventId)
        {
            var guides = await _eventguideService.GetEventGuides(eventId);
            if (guides == null)
            {
                return NotFound();
            }
            return Ok(guides);
        }
    }
}