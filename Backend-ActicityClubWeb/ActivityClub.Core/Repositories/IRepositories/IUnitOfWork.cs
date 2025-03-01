using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;

namespace ActivityClub.Core.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public IAdminRepository Admins { get; }
        public IGuideRepository Guides { get; }
        public IMemberRepository Members { get; }

        public IEventRepository Events { get; }
        public IEventMemberRepository EventMembers { get; }
        public IEventGuideRepository EventGuides { get; }
        public IAuthRepository Authentication { get; }


        //public IMemberRepository Members { get; }
        //IRepository<Role> RoleRepository { get; }
        // IRepository<User> UserRepository { get; }
        //IRepository<UserRole> UserRoleRepository { get; }
        //IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync();
    }

}
