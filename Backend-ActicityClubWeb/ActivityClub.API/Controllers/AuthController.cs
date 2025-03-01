using ActivityClub.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using ActivityClub.API.Requests;
using ActivityClub.Core.DTOs;
using ActivityClub.Core.Models;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using ActivityClub.Core.Repositories.IRepositories;

namespace ActivityClub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthenticationService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            try
            {
                // Map the LoginRequest to User
                var user = _mapper.Map<User>(login);

                // Call the AuthService to handle login and token generation
                var token = await _authService.Login(user);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid UserId, Password, or RoleId.");
                }

                return Ok(new { Token = token }); // Return JWT token
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Handle unexpected exceptions
            }
        }

    }


}
