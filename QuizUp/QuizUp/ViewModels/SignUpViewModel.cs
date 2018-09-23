using QuizUp.Models;
using QuizUp.Services;
using QuizUp.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public SignUpViewModel()
        {
            ResetCommand = new Command(Reset);
            SubmitCommand = new Command(Submit, CanSubmit);
        }

        private bool CanSubmit(object arg)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(FullName);
        }

        private async void Submit(object obj)
        {
            User user = new User();
            user.ID = Guid.NewGuid().ToString();
            user.Name = FullName;
            user.Username = Username;
            user.Password = Password;
            user.ProfileImage = "defaultimage.png";
            user.QuizAttempts = 0;
            bool isUserAdded = await UserService.Instance.UserRepository.AddUserAsync(user);
            OpenNavigationPage(new LoginPage());
        }

        private void Reset(object obj)
        {
            FullName = Username = Password = string.Empty;
        }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged("FullName"); }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }

        public ICommand ResetCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
    }
}
