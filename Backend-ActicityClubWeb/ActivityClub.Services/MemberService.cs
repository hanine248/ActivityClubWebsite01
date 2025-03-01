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
    public class AdminService(IUnitOfWork unitOfWork) : IAdminService
    {
        public async Task AddAsync(Admin entity)
        {
            try
            {
                await unitOfWork.Admins.AddAsync(entity);
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

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return (List<Admin>)await unitOfWork.Admins.GetAllAsync();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await unitOfWork!.Admins.GetByIdAsync(id);
        }

        public Task UpdateAsync(Admin entity)
        {
            throw new NotImplementedException();
        }

        // Implement any specific methods for Admin if needed
    }
}
