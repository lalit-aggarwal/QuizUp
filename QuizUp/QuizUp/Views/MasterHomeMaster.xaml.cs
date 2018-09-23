using QuizUp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterHomeMaster : ContentPage
    {
        public ListView ListView;

        public MasterHomeMaster()
        {
            InitializeComponent();
            ListView = MenuItemsListView;
        }
    }
}