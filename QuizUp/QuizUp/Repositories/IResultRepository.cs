using System.Collections.Generic;
using System.Threading.Tasks;
using QuizUp.Models;

namespace QuizUp.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<bool> AddResultAsync(Result result);

        Task<bool> UpdateResultAsync(Result result);

        Task<List<Result>> GetResultsByUserAsync(string userID);

        Task<Result> GetLastResultByUsedAsync(string userID);
    }
}
