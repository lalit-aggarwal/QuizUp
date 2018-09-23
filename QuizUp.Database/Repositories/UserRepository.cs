using Microsoft.EntityFrameworkCore;
using QuizUp.Models;
using QuizUp.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuizUp.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                var tracking = await _databaseContext.Users.AddAsync(user);
                bool isAdded = tracking.State == EntityState.Added;

                await _databaseContext.SaveChangesAsync();

                return isAdded;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var tracking = _databaseContext.Users.Update(user);
                bool isModified = tracking.State == EntityState.Modified;

                await _databaseContext.SaveChangesAsync();

                return isModified;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var users =  await _databaseContext.Users.ToListAsync();
                return users.FirstOrDefault(user => user.Username.Equals(userName));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User> GetLoggedInUser()
        {
            try
            {
                var users = await _databaseContext.Users.ToListAsync();
                return users.FirstOrDefault(user => user.IsLoggedIn);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password)
        {
            try
            {
                var users = await _databaseContext.Users.ToListAsync();
                return users.FirstOrDefault(user => user.Username.Equals(userName) && user.Password.Equals(password));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
