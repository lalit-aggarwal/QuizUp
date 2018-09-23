using QuizUp.Repositories.Interfaces;

namespace QuizUp.Services
{
    internal class ResultService
    {
        private static ResultService _instance;

        public IResultRepository ResultRepository { get; set; }

        private ResultService() { }

        internal static ResultService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResultService();
                }

                return _instance;
            }
        }
    }
}
