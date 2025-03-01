using System;
using System.Threading.Tasks;
using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;

using ActivityClub.Core.Repositories;

namespace ActivityClub.Core.Repositories
{
    public class UnitOfWork(ActivityClubContext context, IConfiguration configuration) : IUnitOfWork
    {
        private UserRepository? _userRepository;

        public IUserRepository Users =>
            _userRepository ??= new UserRepository(context);

        private AdminRepository? _adminRepository;

        public IAdminRepository Admins =>
            _adminRepository ??= new AdminRepository(context);

        private GuideRepository? _guideRepository;

        public IGuideRepository Guides =>
            _guideRepository ??= new GuideRepository(context);

        private MemberRepository? _memberRepository;

        public IMemberRepository Members =>
            _memberRepository ??= new MemberRepository(context);
        private EventRepository? _eventRepository;
        public IEventRepository Events =>
            _eventRepository ??= new EventRepository(context);

        private EventMemberRepository? _eventmemberRepository;

        public IEventMemberRepository EventMembers =>
            _eventmemberRepository ??= new EventMemberRepository(context);

        private EventGuideRepository? _eventguideRepository;

        public IEventGuideRepository EventGuides =>
            _eventguideRepository ??= new EventGuideRepository(context);

        private AuthRepository? _authRepository;
        public IAuthRepository Authentication =>
            _authRepository ??= new AuthRepository(context, configuration);



        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

