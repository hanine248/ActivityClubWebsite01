using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;

namespace ActivityClub.Core.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ActivityClubContext _dataBaseServerContext;
        private readonly IConfiguration _configuration;

        public AuthRepository(ActivityClubContext dataBaseServerContext, IConfiguration configuration)
        {
            _dataBaseServerContext = dataBaseServerContext;
            _configuration = configuration;
        }

        public async Task<string> Login(User user)
        {
            // Find user by UserId, Password, and RoleId
            var loginUser = await _dataBaseServerContext.Users
                .Where(x => x.Userid == user.Userid && x.Password == user.Password && x.Roleid == user.Roleid) // Add RoleId check
                .FirstOrDefaultAsync();

            if (loginUser == null)
            {
                return string.Empty; // User not found
            }

            // Create JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginUser.Userid.ToString()), // Ensure user ID is included
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, loginUser.Userid.ToString()), // Using the user's ID
                new Claim("role", loginUser.Roleid == 1 ? "admin" : "user") // Set role based on RoleId
                //new Claim("role", loginUser.Roleid == 1 ? "admin" : "user")

            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = creds,
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Return the JWT token
        }
    }
}

