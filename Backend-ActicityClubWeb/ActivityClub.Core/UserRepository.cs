using System.Collections.Generic;
using System.Threading.Tasks;

using ActivityClub.Core.Models;
using ActivityClub.Core.Repositories;
using ActivityClub.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ActivityClub.Core.Repositories
{
    public class UserRepository(DbContext context) : Repository<User>(context), IUserRepository
    {
        private ActivityClubContext myDbContext => (ActivityClubContext)Context;


        public async Task AddAsync(User entity)
        {

            // Add the user first and save to generate the UserId
            await myDbContext.Users.AddAsync(entity);
            await myDbContext.SaveChangesAsync();  // Save to ensure UserId is generated

            // Based on the role, add Member, Guide, or Admin
            if (entity.Roleid == 3)  // Assuming 3 is for Member
            {
                var member = new Member
                {
                    Memberid = entity.Userid,
                    Name= entity.Name,
                              Email = entity.Email,
                    Password = entity.Password,
                    Dateofbirth = entity.Dateofbirth,
                    Nationality = entity.Nationality,
                    Profession = entity.Profession,
                    Phonenumber = entity.Phonenumber,
                    Roleid = entity.Roleid,
                    Datejoining = entity.Datejoining,
                    EmergencyNumber = entity.EmergencyNumber,// Use the same UserId
                };
                await myDbContext.Members.AddAsync(member);  // Add to Members table
            }
            else if (entity.Roleid == 2)  // Assuming 2 is for Guide
            {
                var guide = new Guide
                {
                    Guideid = entity.Userid,
                    Name = entity.Name,
                    Email = entity.Email,
                    Password = entity.Password,
                    Dateofbirth = entity.Dateofbirth,
                    Nationality = entity.Nationality,
                    Profession = entity.Profession,
                    Phonenumber = entity.Phonenumber,
                    Roleid = entity.Roleid,
                    Datejoining = entity.Datejoining,
                    EmergencyNumber = entity.EmergencyNumber,// Use the same UserId
                };
                await myDbContext.Guides.AddAsync(guide);  // Add to Guides table
            }
            else if (entity.Roleid == 1)  // Assuming 1 is for Admin
            {
                var admin = new Admin
                {
                    Adminid = entity.Userid,
                     Email= entity.Email,
                    Name = entity.Name,
                    Password = entity.Password,
                      Dateofbirth = entity.Dateofbirth,
                      Nationality = entity.Nationality,
                      Profession = entity.Profession,
                      Phonenumber = entity.Phonenumber,
                      Roleid = entity.Roleid,
                      Datejoining = entity.Datejoining,
                      EmergencyNumber = entity.EmergencyNumber,

                };
                await myDbContext.Admins.AddAsync(admin);  // Add to Admins table
            }

            // Finally, save the changes for the related entity (Member/Guide/Admin)
            await myDbContext.SaveChangesAsync();
        }

        public override async Task RemoveAsync(User entity)
        {
            // Check if the user exists in the Users table
            var user = await myDbContext.Users.FirstOrDefaultAsync(u => u.Userid == entity.Userid);

            if (user != null)
            {
                // Determine which role the user belongs to and remove from the respective table
                if (user.Roleid == 3)  // Assuming 3 is for Member
                {
                    var member = await myDbContext.Members.FirstOrDefaultAsync(m => m.Memberid == user.Userid);
                    if (member != null)
                    {
                        myDbContext.Members.Remove(member);  // Remove from Members table
                    }
                }
                else if (user.Roleid == 2)  // Assuming 2 is for Guide
                {
                    var guide = await myDbContext.Guides.FirstOrDefaultAsync(g => g.Guideid == user.Userid);
                    if (guide != null)
                    {
                        myDbContext.Guides.Remove(guide);  // Remove from Guides table
                    }
                }
                else if (user.Roleid == 1)  // Assuming 1 is for Admin
                {
                    var admin = await myDbContext.Admins.FirstOrDefaultAsync(a => a.Adminid == user.Userid);
                    if (admin != null)
                    {
                        myDbContext.Admins.Remove(admin);  // Remove from Admins table
                    }
                }

                // Finally, remove the user from the Users table
                myDbContext.Users.Remove(user);

                // Save all changes (user and respective role)
                await myDbContext.SaveChangesAsync();
            }
        }
        public override async Task UpdateAsync(User entity)
        {
            // First, update the User entity itself
            myDbContext.Users.Update(entity);
            await myDbContext.SaveChangesAsync();  // Save changes for User

            // Now, check the role and update the related table
            if (entity.Roleid == 3)  // Assuming 3 is for Member
            {
                var member = await myDbContext.Members.FirstOrDefaultAsync(m => m.Memberid == entity.Userid);
                if (member != null)
                {
                    // Update the related Member fields
                    member.Name = entity.Name;
                    member.Email = entity.Email;
                    member.Password = entity.Password;
                    member.Dateofbirth = entity.Dateofbirth;
                    member.Nationality = entity.Nationality;
                    member.Profession = entity.Profession;
                    member.Phonenumber = entity.Phonenumber;
                    member.Datejoining = entity.Datejoining;
                    member.EmergencyNumber = entity.EmergencyNumber;

                    myDbContext.Members.Update(member);  // Update the Member entity
                }
            }
            else if (entity.Roleid == 2)  // Assuming 2 is for Guide
            {
                var guide = await myDbContext.Guides.FirstOrDefaultAsync(g => g.Guideid == entity.Userid);
                if (guide != null)
                {
                    // Update the related Guide fields
                    guide.Name = entity.Name;
                    guide.Email = entity.Email;
                    guide.Password = entity.Password;
                    guide.Dateofbirth = entity.Dateofbirth;
                    guide.Nationality = entity.Nationality;
                    guide.Profession = entity.Profession;
                    guide.Phonenumber = entity.Phonenumber;
                    guide.Datejoining = entity.Datejoining;
                    guide.EmergencyNumber = entity.EmergencyNumber;

                    myDbContext.Guides.Update(guide);  // Update the Guide entity
                }
            }
            else if (entity.Roleid == 1)  // Assuming 1 is for Admin
            {
                var admin = await myDbContext.Admins.FirstOrDefaultAsync(a => a.Adminid == entity.Userid);
                if (admin != null)
                {
                    // Update the related Admin fields
                    admin.Name = entity.Name;
                    admin.Email = entity.Email;
                    admin.Password = entity.Password;
                    admin.Dateofbirth = entity.Dateofbirth;
                    admin.Nationality = entity.Nationality;
                    admin.Profession = entity.Profession;
                    admin.Phonenumber = entity.Phonenumber;
                    admin.Datejoining = entity.Datejoining;
                    admin.EmergencyNumber = entity.EmergencyNumber;

                    myDbContext.Admins.Update(admin);  // Update the Admin entity
                }
            }

            // Save the changes for the related table (Member, Guide, Admin)
            await myDbContext.SaveChangesAsync();
        }
      
    }
   

}


