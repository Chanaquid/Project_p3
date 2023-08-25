using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetIdByAsync(int id);
        Task<User> GetByUserNameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetWithCartByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id);
        Task<bool> UserExistsAsync(string username, string email);
        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> ValidateUserCredentialAsync(string username, string password);
        Task<User> SignUpAsync(User user, string password);
        Task<User> LoginAsync(string usernameOrEmail, string password);
    }
}