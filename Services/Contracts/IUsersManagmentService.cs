using StudentManagmentApp.Entities;
using StudentManagmentApp.Models;

namespace StudentManagmentApp.Services.Contracts
{
    public interface IUsersManagmentService
    {
        Task<List<UsersModel>> GetUsers();
        Task<Users> AddUsers(UsersModel usersModel);
        Task UpdateUsers(UsersModel usersModel);
        Task DeleteUsers(int id);
    }
}