using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.Repositories
{
    // Repositories/ProfileRepository.cs
    public class ProfileRepository(DbContext context) : IProfileRepository
    {
    {
        private readonly ActivityClubContext _MyDbContext;

        public ProfileRepository(MyDbContext context)
        {
            _context = context;
        }

        public UserProfile GetProfileByUserId(string userId)
        {
            return _context.UserProfiles.FirstOrDefault(p => p.UserId == userId);
        }

        public void UpdateProfile(UserProfile profile)
        {
            _context.UserProfiles.Update(profile);
        }
    }

}
