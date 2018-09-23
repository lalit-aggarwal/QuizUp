using QuizUp.Repositories.Interfaces;

namespace QuizUp.Services
{
    internal class QuestionsService
    {
        private static QuestionsService _instance;

        public IQuestionsRepository QuestionsRepository { get; set; }

        private QuestionsService() { }

        internal static QuestionsService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuestionsService();
                }

                return _instance;
            }
        }
    }
}
