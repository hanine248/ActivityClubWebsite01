using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Services.IServices
{
    public interface IAuthenticationService
    {
        Task<string> Login(User user);
    }


}
