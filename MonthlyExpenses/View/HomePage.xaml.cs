using MonthlyExpenses.Model;
using SQLite;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonthlyExpenses.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conn = new SQLiteConnection(App.DbLocation);           
            conn.CreateTable<Expense>();
            var expenses = conn.Table<Expense>().ToList();
            conn.Close();

            string TotalExpenses()
            {
                string total = null;
                foreach (var item in expenses)
                {                 
                    total += item.Amount;
                }
                return total;
            }
            

            string NumberOfExpenses()
            {
                return expenses.Count.ToString();
            }

            //returns total amount of expenses
            expenseTotal.Text = TotalExpenses();
            //returns total number of expenses saved
            expenseCount.Text = NumberOfExpenses();
            expenseListView.ItemsSource = expenses;

        }

        private void addexpensebtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewExpensePage());
        }

        private void detailBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExpenseDetailPage());
        }
    }
}