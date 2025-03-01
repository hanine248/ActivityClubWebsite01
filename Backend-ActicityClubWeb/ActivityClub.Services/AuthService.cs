using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;
using ActivityClub.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



    namespace ActivityClub.Services
    {
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Login(User user)
        {
            // Validate the user object (checking UserId and Password)
            if (user == null || user.Userid == 0 || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Invalid user credentials.");
            }

            // Call the Login method from AuthRepos
            var token = await _unitOfWork.Authentication.Login(user);

            // Check if the token is empty, indicating failed login
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Invalid UserId or Password.");
            }

            return token; // Return the generated JWT token
        }
    }


}



