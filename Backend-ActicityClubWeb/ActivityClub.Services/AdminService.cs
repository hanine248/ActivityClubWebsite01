using ActivityClub.Core;
using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityClub.Services.IServices;
using ActivityClub.Core.Repositories.IRepositories;
using ActivityClub.Core.DTOs;
using ActivityClub.Services.IServices;

namespace ActivityClub.Services
{
    // AdminService.cs
    public class MemberService(IUnitOfWork unitOfWork) : IMemberService
    {
        public async Task AddAsync(Member entity)
        {
            try
            {
                await unitOfWork.Members.AddAsync(entity);
                await unitOfWork.SaveChangesAsync();
                //   return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //  return null;
            }

            //throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return (List<Member>)await unitOfWork.Members.GetAllAsync();
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await unitOfWork!.Members.GetByIdAsync(id);
        }

        public Task UpdateAsync(Member entity)
        {
            throw new NotImplementedException();
        }

        // Implement any specific methods for Admin if needed
    }
}
