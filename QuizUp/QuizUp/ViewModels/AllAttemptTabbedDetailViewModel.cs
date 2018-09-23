using QuizUp.Models;
using QuizUp.Services;
using System.Collections.Generic;

namespace QuizUp.ViewModels
{
    public class AllAttemptTabbedDetailViewModel: ScoreCardDetailViewModel
    {
        private List<Result> _results { get; set; }

        public AllAttemptTabbedDetailViewModel()
        {
            _results = ResultService.Instance.ResultRepository.GetResultsByUserAsync(User.ID).Result;
            IsResultsAvailable = _results?.Count > 0;
            if (IsResultsAvailable)
            {
                CreateCharts(_results);
            }
        }
    }
}
