using QuizUp.Common;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterHome : MasterDetailPage
    {
        public MasterHome()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        public MasterHome(Type pageType, string title)
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            var page = (Page)Activator.CreateInstance(pageType);
            page.Title = title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterHomeMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}