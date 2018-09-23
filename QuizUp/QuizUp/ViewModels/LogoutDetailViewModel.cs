using QuizUp.Services;
using QuizUp.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class LogoutDetailViewModel: ViewModelBase
    {
        public ICommand LogoutCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public LogoutDetailViewModel()
        {
            LogoutCommand = new Command(Logout);
            CancelCommand = new Command(CancelLogout);
        }

        private void Logout(object obj)
        {
            var user = UserService.Instance.UserRepository.GetLoggedInUser().Result;
            user.IsLoggedIn = false;
            UserService.Instance.UserRepository.UpdateUserAsync(user);
            OpenNavigationPage(new LoginPage());
        }

        private void CancelLogout(object obj)
        {
            OpenMasterPage(new MasterHome());
        }
    }
}
