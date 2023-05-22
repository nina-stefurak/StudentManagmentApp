using Microsoft.EntityFrameworkCore;
using StudentManagmentApp.Data;
using StudentManagmentApp.Entities;
using StudentManagmentApp.Extensions;
using StudentManagmentApp.Models;
using StudentManagmentApp.Services.Contracts;

namespace StudentManagmentApp.Services
{
    public class UsersManagmentService : IUsersManagmentService
    {
        private readonly StudentManagmentDbContext studentManagmentDbContext;

        public UsersManagmentService(StudentManagmentDbContext studentManagmentDbContext)
        {
            this.studentManagmentDbContext = studentManagmentDbContext;
        }

        public async Task<Users> AddUsers(UsersModel usersModel)
        {
            try
            {
                Users usersToAdd = usersModel.Convert();
                
                var result = await this.studentManagmentDbContext.Users.AddAsync(usersToAdd);
                
                await this.studentManagmentDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteUsers(int id)
        {
            try
            {
                var users = await this.studentManagmentDbContext.Users.FindAsync(id);
                if (users != null)
                {
                    this.studentManagmentDbContext.Users.Remove(users);
                    await this.studentManagmentDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UsersModel>> GetUsers() 
        {
            //retrive users data from our database
            try
            {
                return await this.studentManagmentDbContext.Users.Convert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateUsers(UsersModel usersModel)
        {
            try
            {
                var usersToUpdate = await this.studentManagmentDbContext.Users.FindAsync(usersModel.Id);

                if (usersToUpdate != null)
                {
                    usersToUpdate.FirstName = usersModel.FirstName;
                    usersToUpdate.LastName = usersModel.LastName;
                    usersToUpdate.Email = usersModel.Email;
                    usersToUpdate.Technologies = usersModel.Technologies;
                    usersToUpdate.ProgrammingLanguages = usersModel.ProgrammingLanguages;
                    usersToUpdate.SkillsRating = usersModel.SkillsRating;

                    await this.studentManagmentDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
