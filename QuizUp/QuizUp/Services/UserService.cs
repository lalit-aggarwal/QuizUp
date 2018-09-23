using QuizUp.Repositories.Interfaces;

namespace QuizUp.Services
{
    internal class UserService
    {
        private static UserService _instance;
        public IUserRepository UserRepository { get; set; }

        private UserService() { }

        internal static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserService();
                }

                return _instance;
            }
        }
    }
}
