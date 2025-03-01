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
using Microsoft.AspNetCore.Authorization;

namespace ActivityClub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService; // Use IService<Admin>
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAdmins()
        {
            try
            {
                var admins = await _adminService.GetAllAsync();
                var adminDtos = _mapper.Map<IEnumerable<AdminDTO>>(admins);
                return Ok(adminDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDTO>> GetAdmin(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            var adminDto = _mapper.Map<AdminDTO>(admin);
            return Ok(adminDto);
        }

        // POST: api/Admin
        [HttpPost]
        public async Task<ActionResult<AdminDTO>> PostAdmin(AdminDTO adminDto)
        {
            var admin = _mapper.Map<Admin>(adminDto);
            await _adminService.AddAsync(admin);
            var createdAdminDto = _mapper.Map<AdminDTO>(admin);
            return CreatedAtAction(nameof(GetAdmin), new { id = createdAdminDto.Adminid }, createdAdminDto);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, AdminDTO adminDto)
        {
            if (id != adminDto.Adminid)
            {
                return BadRequest();
            }

            var admin = _mapper.Map<Admin>(adminDto);
            await _adminService.UpdateAsync(admin);

            return NoContent();
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            await _adminService.DeleteAsync(id);

            return NoContent();
        }
    }
}




