using System.Collections.Generic;
using System.Threading.Tasks;

using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ActivityClub.Core.Repositories
{
    public class MemberRepository(DbContext context) : Repository<Member>(context), IMemberRepository
    {
        private ActivityClubContext myDbContext => (ActivityClubContext)Context;

    }
}
