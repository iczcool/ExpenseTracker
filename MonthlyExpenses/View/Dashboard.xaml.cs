using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonthlyExpenses.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        private double incomeValue = 1300.00;
        public Dashboard()
        {
            InitializeComponent();
            Variable();
            Constant();
            Savings();
        }

        private void Variable()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                //App.Current.MainPage.DisplayAlert("Message", "This is not yet implemented", "OK");
                Navigation.PushAsync(new VariableExpensesPage());
            };
            variable.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void Constant()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new HomePage());
            };
            constant.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void Savings()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                App.Current.MainPage.DisplayAlert("Message", "This is not yet implemented", "OK");
            };
            savings.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public string TotalSavings()
        {
            var homePage = new HomePage();
            var vePage = new VariableExpensesPage();
            double tot = incomeValue - (homePage.TotalExpenses() + vePage.TotalExpenses());
            return savingsAmount.Text = "£ " + tot.ToString();
        }

        protected override void OnAppearing()
        {
            HomePage homePage = new HomePage();
            VariableExpensesPage vePage = new VariableExpensesPage();
            double tot = homePage.TotalExpenses() + vePage.TotalExpenses();
            base.OnAppearing();
            income.Text = "£ " + incomeValue.ToString();
            currentDate.Text = DateTime.Now.ToShortDateString();
            expenseTotal.Text = tot.ToString();

            constantAmount.Text = homePage.TotalExpenses().ToString();
            variableAmount.Text = vePage.TotalExpenses().ToString();
            savingsAmount.Text = TotalSavings();
        }
    }
}