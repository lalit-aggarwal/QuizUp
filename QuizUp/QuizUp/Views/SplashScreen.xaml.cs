using QuizUp.Common;
using QuizUp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashScreen : ContentPage
	{
		public SplashScreen ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SplashImage.ScaleTo(AppConstants.INITIAL_SCALE, AppConstants.INITIAL_TIME);
            await SplashImage.ScaleTo(AppConstants.CUBIC_IN_SCALE, AppConstants.CUBIC_IN_TIME, Easing.CubicIn);
            await SplashImage.ScaleTo(AppConstants.CUBIC_OUT_SCALE, AppConstants.CUBIC_OUT_TIME, Easing.CubicOut);
            var user = UserService.Instance.UserRepository.GetLoggedInUser().Result;
            if (user != null)
            {
                Application.Current.MainPage = new MasterHome();
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}