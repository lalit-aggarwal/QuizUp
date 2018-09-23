using QuizUp.Common;
using QuizUp.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizUp.ViewModels
{
    public class MasterHomeDetailViewModel: ViewModelBase
    {
        public ICommand StartQuizCommand { get; private set; }

        public MasterHomeDetailViewModel()
        {
            StartQuizCommand = new Command(StartQuiz);
        }

        private void StartQuiz(object obj)
        {
            OpenMasterPage(new MasterHome(typeof(TakeQuizDetail), AppConstants.QUIZ));
        }
    }
}
