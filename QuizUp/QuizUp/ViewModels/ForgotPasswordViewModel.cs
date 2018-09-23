using QuizUp.Services;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); SubmitCommand.ChangeCanExecute(); }
        }

        public Command SubmitCommand { get; set; }

        public ForgotPasswordViewModel()
        {
            SubmitCommand = new Command(SubmitUsername, CanSubmitUsername);
        }

        private bool CanSubmitUsername(object arg)
        {
            return !string.IsNullOrEmpty(Username);
        }

        private async void SubmitUsername(object obj)
        {
            var user = await UserService.Instance.UserRepository.GetUserByUserNameAsync(Username);
            Message = user != null ? "Your password is: " + user.Password : "User does not exists.";
        }
    }
}