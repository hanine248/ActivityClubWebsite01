using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityClub.Core.Repositories.IRepositories
{

    public interface IAuthRepository
    {
        Task<string> Login(User user);

    }

}
