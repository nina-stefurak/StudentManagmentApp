using Microsoft.EntityFrameworkCore;
using StudentManagmentApp.Entities;
using StudentManagmentApp.Models;

namespace StudentManagmentApp.Extensions
{
    public static class Conversions
    {
        public static async Task<List<UsersModel>> Convert(this IQueryable<Users> users)//returns a list of users model objects
        {
            return await (from u in users 
                          select new UsersModel
                        {
                              Id = u.Id,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              Email = u.Email,
                              Technologies = u.Technologies,
                              ProgrammingLanguages = u.ProgrammingLanguages,
                              SkillsRating = u.SkillsRating,

                        }).ToListAsync();
        }
        public static Users Convert(this UsersModel usersModel)
        {
            return new Users
            {
                FirstName = usersModel.FirstName,
                LastName = usersModel.LastName,
                Email = usersModel.Email,
                Technologies = usersModel.Technologies,
                ProgrammingLanguages = usersModel.ProgrammingLanguages,
                SkillsRating = usersModel.SkillsRating,
            };

        }
    }
}
