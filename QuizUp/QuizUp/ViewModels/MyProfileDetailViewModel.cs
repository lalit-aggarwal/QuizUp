using QuizUp.Models;
using QuizUp.Services;
using QuizUp.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class MyProfileDetailViewModel: ViewModelBase
    {
        private string _newPassword;

        private bool _isPasswordChange;

        public bool IsPasswordChange
        {
            get
            {
                return _isPasswordChange;
            }
            set
            {
                _isPasswordChange = value;
                OnPropertyChanged("IsPasswordChange");
            }
        }

        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged("NewPassword");
            }
        }

        public User User { get; private set; }

        public ICommand UpdateCommand { get; private set; }

        public ICommand CancelUpdateCommand { get; private set; }

        public MyProfileDetailViewModel()
        {
            User = UserService.Instance.UserRepository.GetLoggedInUser().Result;
            User.Password = IsPasswordChange ? NewPassword : User.Password;
            UpdateCommand = new Command(Update);
            CancelUpdateCommand = new Command(CancelUpdate);
        }

        private void Update(object obj)
        {
            UserService.Instance.UserRepository.UpdateUserAsync(User);
            OpenMasterPage(new MasterHome());
        }

        private void CancelUpdate(object obj)
        {
            OpenMasterPage(new MasterHome());
        }
    }
}
