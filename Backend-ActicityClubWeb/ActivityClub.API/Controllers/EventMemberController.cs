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
    public class EventMemberController : ControllerBase
    {
        private readonly IEventMemberService _eventmemberService; // Use IService<Admin>
        private readonly IMapper _mapper;
    
        private readonly IEventService _eventService;

        public EventMemberController(IEventMemberService eventmemberService, IMapper mapper)
        {
            _eventmemberService = eventmemberService;
            _mapper = mapper;
        }
        [HttpPost("add-member")]
     
        public async Task<ActionResult<EventMemberDTO>> PostEvent(EventMemberDTO eventmemberDto)
        {
            var eventmembers = _mapper.Map<EventMember>(eventmemberDto);
            await _eventmemberService.AddAsync(eventmembers);
            var createdEventMemberDto = _mapper.Map<EventMemberDTO>(eventmembers);
            return CreatedAtAction(nameof(GetEventMember), new { id = createdEventMemberDto.Eventid }, createdEventMemberDto);
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventMemberDTO>>> GetEventMember()
        {
            try
            {
                var eventmembers = await _eventmemberService.GetAllAsync();
                var eventmemberDtos = _mapper.Map<IEnumerable<EventMemberDTO>>(eventmembers);
                return Ok(eventmemberDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventMemberDTO>> GetEventMember(int id)
        {
            var eventmembers = await _eventmemberService.GetByIdAsync(id);
            if (eventmembers == null)
            {
                return NotFound();
            }
            var eventmemberDto = _mapper.Map<EventMemberDTO>(eventmembers);
            return Ok(eventmemberDto);
        }

       

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventMemberDTO eventmemberDto)
        {
            if (id != eventmemberDto.Eventmemberid)
            {
                return BadRequest();
            }

            var eventmembers = _mapper.Map<EventMember>(eventmemberDto);
            await _eventmemberService.UpdateAsync(eventmembers);

            return NoContent();
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventMember(int id)
        {
            var eventmembers = await _eventmemberService.GetByIdAsync(id);
            if (eventmembers == null)
            {
                return NotFound();
            }

            await _eventmemberService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("event/{eventId}/members")]
        public async Task<ActionResult<List<MemberDTO>>> GetEventMembers(int eventId)
        {
            var members = await _eventmemberService.GetEventMembers(eventId);
            if (members == null)
            {
                return NotFound();
            }
            return Ok(members);
        }
    }
}

