using QuizUp.Common;
using QuizUp.Models;
using QuizUp.Services;
using QuizUp.Views;
using System.Collections.ObjectModel;

namespace QuizUp.ViewModels
{
    public class MasterHomeMasterViewModel : ViewModelBase
    {
        public User User { get; private set; }

        public ObservableCollection<MasterHomeMenuItem> MasterMenuItems { get; set; }

        public MasterHomeMasterViewModel()
        {
            User = UserService.Instance.UserRepository.GetLoggedInUser().Result;
            MasterMenuItems = new ObservableCollection<MasterHomeMenuItem>(new[]
            {
                    new MasterHomeMenuItem { Id = 0, Title = AppConstants.HOME, Image="home.png", TargetType=typeof(MasterHomeDetail) },
                    new MasterHomeMenuItem { Id = 1, Title = AppConstants.QUIZ, Image="takequiz.png", TargetType=typeof(TakeQuizDetail) },
                    new MasterHomeMenuItem { Id = 2, Title = AppConstants.SCORECARD, Image="results.png", TargetType=typeof(ScoreCardDetail) },
                    new MasterHomeMenuItem { Id = 3, Title = AppConstants.MYPROFILE, Image="profile.png", TargetType=typeof(MyProfileDetail) },
                    new MasterHomeMenuItem { Id = 4, Title = AppConstants.ABOUTUS, Image="aboutus.png", TargetType=typeof(AboutUsDetail) },
                    new MasterHomeMenuItem { Id = 5, Title = AppConstants.LOGOUT, Image="logout.png", TargetType=typeof(LogoutDetail) }
                });
        }
    }
}
