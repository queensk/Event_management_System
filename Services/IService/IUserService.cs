using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_management_System.Model;
using Event_management_System.Requests;

namespace Event_management_System.Services.IService
{
    public interface IUserService
    {
        //Adding a User
        Task<string> AddUserAsync(User user);
        //update
        Task<string> UpdateUserAsync(User user);
        //delete
        Task<string> DeleteUserAsync(User user);

        //Get All User
        Task<IEnumerable<User>> GetAllUsersAsync();
        
        //Get One User
        Task<User> GetUserByIdAsync(Guid id);
        //buy course
        Task<string> RegisterEventAsync(RegisterEvent registerEvent);

        Task<User> GetUserByEmailAsync(string Email);
    }
}