using QuizUp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizUp.Repositories.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<List<Question>> GetQuestions(int numberOfQuestions);
    }
}
