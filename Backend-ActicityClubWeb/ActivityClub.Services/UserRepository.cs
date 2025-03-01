using ActivityClub.Core;
using ActivityClub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityClub.Services.IServices;
using ActivityClub.Core.Repositories.IRepositories;
using ActivityClub.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ActivityClub.Services
{
    // AdminService.cs
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        public async Task AddAsync(User entity)
        {
            try
            {
                await unitOfWork.Users.AddAsync(entity);
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



        public async Task RemoveAsync(int id)
        {
            try
            {
                // Step 1: Retrieve the user by ID using UnitOfWork
                var user = await unitOfWork.Users.GetByIdAsync(id);

                if (user == null)
                {
                    // Step 2: Handle the case where the user does not exist
                    throw new KeyNotFoundException($"User with ID {id} not found.");
                }

                // Step 3: Remove the user (this should handle related records in UserRepository)
                await unitOfWork.Users.RemoveAsync(user);

                // Step 4: Commit the transaction by saving changes via UnitOfWork
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Step 5: Handle any exceptions
                Console.WriteLine($"Error removing user: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return (List<User>)await unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await unitOfWork!.Users.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User entity)
        {
            try
            {
                await unitOfWork.Users.UpdateAsync(entity);
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
     
    }

    // Implement any specific methods for Admin if needed
}
