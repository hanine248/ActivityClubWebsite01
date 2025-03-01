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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; // Use IService<Admin>
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);
                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostAdmin(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.AddAsync(user);
            var createdUserDto = _mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUserDto.Userid }, createdUserDto);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, UserDTO userDto)
        {
            if (id != userDto.Userid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userDto);
            await _userService.UpdateAsync(user);

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Retrieve the user by id
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                // Return NotFound if the user doesn't exist
                return NotFound();
            }

            // Remove the user via the service
            await _userService.RemoveAsync(id);

            // Return NoContent to indicate successful deletion
            return NoContent();
        }
      
    }

}

