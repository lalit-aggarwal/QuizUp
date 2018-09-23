using QuizUp.Models;
using System.Threading.Tasks;

namespace QuizUp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetLoggedInUser();

        Task<User> GetUserByUserNameAsync(string userName);

        Task<bool> AddUserAsync(User user);

        Task<bool> UpdateUserAsync(User user);

        Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password);
    }
}
