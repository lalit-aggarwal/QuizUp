namespace QuizUp.Models
{
    /// <summary>
    /// Represents result in database
    /// </summary>
    public class Result
    {
        public string ID { get; set; }

        public string UserID { get; set; }

        public int QuestionsAttempted { get; set; }

        public int QuestionsUnattempted { get; set; }

        public int CorrectAnswers { get; set; }

        public int TotalQuestions { get; set; }

        public int IncorrectAnswers { get; set; }

        public long TotalTimeTaken { get; set; }
    }
}
