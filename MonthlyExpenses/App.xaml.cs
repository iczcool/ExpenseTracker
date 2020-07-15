using MonthlyExpenses.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonthlyExpenses
{
    public partial class App : Application
    {
        public static string DbLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Dashboard());
        }
        public App(string dbLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Dashboard());
            DbLocation = dbLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
