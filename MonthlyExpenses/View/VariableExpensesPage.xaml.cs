using MonthlyExpenses.Model;
using MonthlyExpenses.ViewModel;
using SQLite;
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
    public partial class VariableExpensesPage : ContentPage
    {
        public VariableExpensesPage()
        {
            InitializeComponent();
            BindingContext = new VEPageViewModel();
        }

        public double TotalExpenses()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<VariableExpense>();
            var variableExpenses = conn.Table<VariableExpense>().ToList();
            conn.Close();

            double total = 0;
            foreach (var item in variableExpenses)
            {
                total += item.Amount;
            }
            return total;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<VariableExpense>();
            var variableExpenses = conn.Table<VariableExpense>().ToList();
            conn.Close();
           
            //returns total amount of expenses
            expenseTotal.Text = TotalExpenses().ToString();
            //returns total number of expenses saved
            expenseCount.Text = variableExpenses.Count.ToString();
            expenseListView.ItemsSource = variableExpenses;
        }

        private void addVExpense_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewVEPage());
        }

        private void detailBtn_Clicked(object sender, EventArgs e)
        {
            int myId;
            var buttonClickedHandler = (Button)sender;
            Grid parentGrid = (Grid)buttonClickedHandler.Parent;
            Label idLabel = (Label)parentGrid.Children[0];
            myId = int.Parse(idLabel.Text);
            Navigation.PushAsync(new VEDetailPage(myId));
        }
    }
}