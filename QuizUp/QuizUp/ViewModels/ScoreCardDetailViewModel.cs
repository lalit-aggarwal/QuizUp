using Microcharts;
using QuizUp.Models;
using QuizUp.Services;
using SkiaSharp;
using System.Collections.Generic;

namespace QuizUp.ViewModels
{
    public class ScoreCardDetailViewModel : ViewModelBase
    {
        private Chart _attemptsChartView;

        private Chart _answersScoreChartView;

        private Chart _attemptedQuestionChartView;

        private bool _isResultsAvailable;

        public User User { get; set; }

        public bool IsResultsAvailable
        {
            get
            {
                return _isResultsAvailable;
            }
            set
            {
                _isResultsAvailable = value;
                OnPropertyChanged("IsResultsAvailable");
            }
        }

        public Chart AttemptedQuestionChartView
        {
            get { return _attemptedQuestionChartView; }
            set { _attemptedQuestionChartView = value; OnPropertyChanged("AttemptedQuestionChartView"); }
        }

        public Chart AnswersScoreChartView
        {
            get { return _answersScoreChartView; }
            set { _answersScoreChartView = value; OnPropertyChanged("AnswersScoreChartView"); }
        }

        public Chart AttemptsChartView
        {
            get
            {
                return _attemptsChartView;
            }
            set
            {
                _attemptsChartView = value;
                OnPropertyChanged("AttemptsChartView");
            }
        }

        public ScoreCardDetailViewModel()
        {
            User = UserService.Instance.UserRepository.GetLoggedInUser().Result;
        }

        protected void CreateCharts(List<Result> results)
        {
            List<Entry> entries = new List<Entry>();
            long totalTimeTaken = 0;
            int totalQuestionsInAttempts = 0;
            float totalAttemptedQuestions = 0;
            int totalUnattemptedQuestions = 0;
            float totalCorrectQuestions = 0;
            int totalInCorrectlyAnsweredQuestions = 0;
            float accuracy = 0;

            results.ForEach(result =>
            {
                totalTimeTaken += result.TotalTimeTaken;
                totalQuestionsInAttempts += result.TotalQuestions;
                totalAttemptedQuestions += result.QuestionsAttempted;
                totalUnattemptedQuestions += result.QuestionsUnattempted;
                totalCorrectQuestions += result.CorrectAnswers;
                totalInCorrectlyAnsweredQuestions += result.IncorrectAnswers;
            });

            accuracy = (totalCorrectQuestions / totalAttemptedQuestions) * 100;

            entries.Add(new Entry(accuracy)
            {
                Color = SKColor.Parse("#66023C"),
                Label = "Accuracy",
                ValueLabel = accuracy.ToString("0.00") + "%"
            });

            entries.Add(new Entry(totalTimeTaken / 1000)
            {
                Color = SKColor.Parse("#00BFFF"),
                Label = "Time Taken",
                ValueLabel = (totalTimeTaken / 1000).ToString() + "s"
            });

            AttemptsChartView = new BarChart() { Entries = entries, LabelTextSize = 30 };

            entries = new List<Entry>();

            entries.Add(new Entry(totalCorrectQuestions)
            {
                Color = SKColor.Parse("#50C878"),
                Label = "Correct Answers",
                ValueLabel = totalCorrectQuestions.ToString()
            });

            entries.Add(new Entry(totalInCorrectlyAnsweredQuestions)
            {
                Color = SKColor.Parse("#BC5449"),
                Label = "Incorrect Answers",
                ValueLabel = totalInCorrectlyAnsweredQuestions.ToString()
            });

            AnswersScoreChartView = new DonutChart() { Entries = entries, LabelTextSize = 30 };

            entries = new List<Entry>();

            entries.Add(new Entry(totalAttemptedQuestions)
            {
                Color = SKColor.Parse("#0080FF"),
                Label = "Attempted",
                ValueLabel = totalAttemptedQuestions.ToString()
            });

            entries.Add(new Entry(totalUnattemptedQuestions)
            {
                Color = SKColor.Parse("#FDA172"),
                Label = "Unattempted",
                ValueLabel = totalUnattemptedQuestions.ToString()
            });

            entries.Add(new Entry(totalQuestionsInAttempts)
            {
                Color = SKColor.Parse("#00CED1"),
                Label = "Total Questions",
                ValueLabel = totalQuestionsInAttempts.ToString()
            });

            AttemptedQuestionChartView = new RadialGaugeChart() { Entries = entries, LabelTextSize = 30 };
        }
    }
}
