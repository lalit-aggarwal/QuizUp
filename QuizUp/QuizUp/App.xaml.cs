using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using QuizUp.Repositories.Interfaces;
using QuizUp.Services;
using QuizUp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QuizUp
{
    public partial class App : Application
    {
        public App(IUserRepository userRepository, IQuestionsRepository questionsRepository, IResultRepository resultRepository)
        {
            InitializeComponent();
            UserService.Instance.UserRepository = userRepository;
            QuestionsService.Instance.QuestionsRepository = questionsRepository;
            ResultService.Instance.ResultRepository = resultRepository;
            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=c907053c-c15e-40b8-be41-d0399e4d7238;",
                  typeof(Analytics), typeof(Crashes));
            AppCenter.Start("android=c907053c-c15e-40b8-be41-d0399e4d7238;" + "uwp={Your UWP App secret here};" + "ios={Your iOS App secret here}", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
