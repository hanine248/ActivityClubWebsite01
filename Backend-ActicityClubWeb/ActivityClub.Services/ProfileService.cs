using ActivityClub.Core.Repositories.IRepositories;
using ActivityClub.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Services
{
    // Services/ProfileService.cs
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserProfile GetProfile(string userId)
        {
            return _unitOfWork.ProfileRepository.GetProfileByUserId(userId);
        }

        public void UpdateProfile(UserProfile profile)
        {
            _unitOfWork.ProfileRepository.UpdateProfile(profile);
            _unitOfWork.Complete();
        }
    }

}
