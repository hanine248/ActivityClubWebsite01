using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Services.IServices
{
    class IProfileService
    {
        UserProfile GetProfile(string userId);
        void UpdateProfile(UserProfile profile);
    }
}
