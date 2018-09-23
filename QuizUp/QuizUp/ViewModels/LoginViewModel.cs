using QuizUp.Services;
using QuizUp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Private fields

        private string _username;
        private string _password;

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new Command(Login, CanLogin);
            ResetCommand = new Command(Reset);
            OpenSignUpPageCommand = new Command(OpenSignUp);
            OpenForgotPasswordPageCommand = new Command(OpenForgotPassword);
            LoginWithFacebookCommand = new Command(LoginWithFacebook);
        }

        #endregion

        #region Properties

        public ICommand OpenSignUpPageCommand { get; private set; }

        public ICommand OpenForgotPasswordPageCommand { get; private set; }

        public Command LoginCommand { get; private set; }

        public Command LoginWithFacebookCommand { get; private set; }

        public ICommand ResetCommand { get; private set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); LoginCommand.ChangeCanExecute(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); LoginCommand.ChangeCanExecute(); }
        }

        #endregion

        #region Private Methods

        private async void LoginWithFacebook(object obj)
        {
            await Navigate(new FacebookProfileCsPage());
        }

        private void Reset(object obj)
        {
            Username = string.Empty;
            Password = string.Empty;
            Message = string.Empty;
        }

        private bool CanLogin(object arg)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private async void Login(object obj)
        {
            var user = await UserService.Instance.UserRepository.GetUserByUserNameAndPasswordAsync(Username, Password);
            if (user != null)
            {
                user.IsLoggedIn = true;
                await UserService.Instance.UserRepository.UpdateUserAsync(user);
                OpenMasterPage(new MasterHome());
            }
            else
            {
                Message = "Incorrect username or password";
            }
        }

        private async void OpenForgotPassword(object obj)
        {
            await Navigate(new ForgotPasswordPage());
        }

        private async void OpenSignUp(object obj)
        {
            await Navigate(new SignUpPage());
        }

        #endregion
    }
}
