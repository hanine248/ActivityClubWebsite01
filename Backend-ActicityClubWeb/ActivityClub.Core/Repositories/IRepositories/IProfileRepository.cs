using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.Repositories.IRepositories
{
    // Repositories/IProfileRepository.cs
    public interface IProfileRepository
    {
        UserProfile GetProfileByUserId(string userId);
        void UpdateProfile(UserProfile profile);
    }

}
