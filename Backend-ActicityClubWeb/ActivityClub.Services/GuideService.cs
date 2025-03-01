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
    public class GuideService(IUnitOfWork unitOfWork) : IGuideService
    {
        public async Task AddAsync(Guide entity)
        {
            try
            {
                await unitOfWork.Guides.AddAsync(entity);
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

        public async Task<IEnumerable<Guide>> GetAllAsync()
        {
            return (List<Guide>)await unitOfWork.Guides.GetAllAsync();
        }

        public async Task<Guide> GetByIdAsync(int id)
        {
            return await unitOfWork!.Guides.GetByIdAsync(id);
        }

        public Task UpdateAsync(Guide entity)
        {
            throw new NotImplementedException();
        }

        // Implement any specific methods for Admin if needed
    }
}
