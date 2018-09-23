using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Private Fields

        private string _message;

        #endregion

        #region Constructor

        public ViewModelBase()
        {
            _message = string.Empty;
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Properties

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        #endregion

        #region Navigate

        public void OpenMasterPage(Page page)
        {
            Application.Current.MainPage = page;
        }

        public void OpenNavigationPage(Page page)
        {
            Application.Current.MainPage = new NavigationPage(page);
        }

        public async Task Navigate(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        #endregion
    }
}
