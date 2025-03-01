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

namespace ActivityClub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService; 
        private readonly IMapper _mapper;

        public MemberController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetMembers()
        {
            try
            {
                var members = await _memberService.GetAllAsync();
                var memberDtos = _mapper.Map<IEnumerable<MemberDTO>>(members);
                return Ok(memberDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDTO>> GetMember(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            var memberDto = _mapper.Map<MemberDTO>(member);
            return Ok(memberDto);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<MemberDTO>> PostMember(MemberDTO memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            await _memberService.AddAsync(member);
            var createdMemberDto = _mapper.Map<MemberDTO>(member);
            return CreatedAtAction(nameof(GetMember), new { id = createdMemberDto.Memberid }, createdMemberDto);
        }

        // PUT: api/Member/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, MemberDTO memberDto)
        {
            if (id != memberDto.Memberid)
            {
                return BadRequest();
            }

            var member = _mapper.Map<Member>(memberDto);
            await _memberService.UpdateAsync(member);

            return NoContent();
        }

        // DELETE: api/Member/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            await _memberService.DeleteAsync(id);

            return NoContent();
        }
    }
}


