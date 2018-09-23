using QuizUp.Models;
using QuizUp.Services;
using System.Collections.Generic;

namespace QuizUp.ViewModels
{
    public class LastAttemptTabbedDetailViewModel: ScoreCardDetailViewModel
    {
        private Result _result;

        public LastAttemptTabbedDetailViewModel()
        {
            _result = ResultService.Instance.ResultRepository.GetLastResultByUsedAsync(User.ID).Result;
            IsResultsAvailable = _result != null;
            if(IsResultsAvailable)
            {
                CreateCharts(new List<Result> { _result });
            }
        }
    }
}
