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
    public partial class NewExpensePage : ContentPage
    {
        public NewExpensePage()
        {
            NewExpensePageViewModel newExpensePage = new NewExpensePageViewModel();
            InitializeComponent();
            BindingContext = newExpensePage;
        }

        private void cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }

        private void addbtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ExpenseName.Text) || string.IsNullOrEmpty(Amount.Text))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Expense details", "OK");
            else
            {
                SQLiteConnection conn = new SQLiteConnection(App.DbLocation);
                conn.CreateTable<Expense>();

                Expense exp = new Expense();
                exp.Name = ExpenseName.Text;
                exp.Amount = Double.Parse(Amount.Text);
                exp.DueDate = DueDate.Date;
                exp.PaymentMethod = PaymentMethod.Text;
                exp.Company = Company.Text;
                int rows = 0;  
                try
                {
                    rows = conn.Insert(exp);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (rows > 0)
                {
                    DisplayAlert("Success", "New Expense added", "Ok");
                    //App.Current.MainPage.DisplayAlert("Success", "New Expense added", "Ok");
                    App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    DisplayAlert("OOps!!!", "There was a problem. Please try again", "ERROR");
                }

                
            }
        }
    }
}