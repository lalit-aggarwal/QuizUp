
using Android.App;
using Android.Content.PM;
using Android.OS;
using QuizUp.Database.Repositories;
using System.IO;

namespace QuizUp.Droid
{
    [Activity(Label = "QuizUp", Icon = "@drawable/quizup", Theme = "@style/MainTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleInstance, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "QuizUpDB.db");
            var userRepository = new UserRepository(dbPath);
            var questionsRepository = new QuestionsRepository(dbPath);
            var resultRepository = new ResultRepository(dbPath);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(userRepository, questionsRepository, resultRepository));
        }
    }
}

