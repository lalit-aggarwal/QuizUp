using QuizUp.Common;
using QuizUp.Models;
using QuizUp.Services;
using QuizUp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class TakeQuizDetailViewModel: ViewModelBase
    {
        private Stopwatch stopWatch;

        private List<Question> _questions;

        public List<Question> Questions
        {
            get
            {
                return _questions;
            }
            set
            {
                _questions = value;
                OnPropertyChanged("Questions");
            }
        }

        public ICommand SubmitCommand { get; private set; }

        public ICommand ClearCommand { get; private set; }

        public TakeQuizDetailViewModel()
        {
            stopWatch = new Stopwatch();
            SubmitCommand = new Command(Submit);
            ClearCommand = new Command(Clear);
            Questions = QuestionsService.Instance.QuestionsRepository.GetQuestions(10).Result;
            Clear(null);
            stopWatch.Start();
        }

        private async void Submit(object obj)
        {
            long totalTimeTaken = stopWatch.ElapsedMilliseconds;
            var user = UserService.Instance.UserRepository.GetLoggedInUser().Result;
            user.QuizAttempts++;
            await UserService.Instance.UserRepository.UpdateUserAsync(user);
            await PrepareResults(user, totalTimeTaken);
            OpenMasterPage(new MasterHome(typeof(ScoreCardDetail), AppConstants.SCORECARD));
        }

        private async Task PrepareResults(User user, long totalTimeTaken)
        {
            Result result = new Result();
            result.ID = Guid.NewGuid().ToString();
            result.UserID = user.ID;
            result.TotalTimeTaken = totalTimeTaken;
            result.TotalQuestions = Questions.Count;
            result.CorrectAnswers = Questions.Count(question => question.SelectedAnswer != null && question.SelectedAnswer.Equals(question.Answer));
            result.QuestionsAttempted = Questions.Count(question => question.SelectedAnswer != null);
            result.IncorrectAnswers = result.QuestionsAttempted - result.CorrectAnswers;
            result.QuestionsUnattempted = result.TotalQuestions - result.QuestionsAttempted;
            await ResultService.Instance.ResultRepository.AddResultAsync(result);
        }

        private void Clear(object obj)
        {
           foreach(Question question in Questions)
            {
                question.SelectedAnswer = null;
            }
        }
    }
}
