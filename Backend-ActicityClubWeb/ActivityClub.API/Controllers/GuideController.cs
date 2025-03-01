using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using ActivityClub.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
// Ensure this namespace is correct

namespace ActivityClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService; // Use IGuideService
        private readonly IMapper _mapper;

        public GuideController(IGuideService guideService, IMapper mapper)
        {
            _guideService = guideService;
            _mapper = mapper;
        }

        // GET: api/Guide
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuideDTO>>> GetGuides()
        {
            try
            {
                var guides = await _guideService.GetAllAsync();
                var guideDtos = _mapper.Map<IEnumerable<GuideDTO>>(guides);
                return Ok(guideDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Guide/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuideDTO>> GetGuide(int id)
        {
            var guide = await _guideService.GetByIdAsync(id);
            if (guide == null)
            {
                return NotFound();
            }
            var guideDto = _mapper.Map<GuideDTO>(guide);
            return Ok(guideDto);
        }

        // POST: api/Guide
        [HttpPost]
        public async Task<ActionResult<GuideDTO>> PostGuide(GuideDTO guideDto)
        {
            var guide = _mapper.Map<Guide>(guideDto);
            await _guideService.AddAsync(guide);
            var createdGuideDto = _mapper.Map<GuideDTO>(guide);
            return CreatedAtAction(nameof(GetGuide), new { id = createdGuideDto.Guideid }, createdGuideDto);
        }

        // PUT: api/Guide/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuide(int id, GuideDTO guideDto)
        {
            if (id != guideDto.Guideid)
            {
                return BadRequest();
            }

            var guide = _mapper.Map<Guide>(guideDto);
            await _guideService.UpdateAsync(guide);

            return NoContent();
        }

        // DELETE: api/Guide/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var guide = await _guideService.GetByIdAsync(id);
            if (guide == null)
            {
                return NotFound();
            }

            await _guideService.DeleteAsync(id);

            return NoContent();
        }
    }
}





