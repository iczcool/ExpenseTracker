using MonthlyExpenses.Model;
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
    public partial class NewVEPage : ContentPage
    {
        public NewVEPage()
        {
            InitializeComponent();
            BindingContext = new VariableExpense();
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
                conn.CreateTable<VariableExpense>();

                VariableExpense exp = new VariableExpense();
                exp.Name = ExpenseName.Text;
                exp.Amount = Double.Parse(Amount.Text);
                exp.DueDate = DueDate.Date;
                exp.Description = Description.Text;
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
                    App.Current.MainPage.Navigation.PushAsync(new VariableExpensesPage());
                }
                else
                {
                    DisplayAlert("OOps!!!", "There was a problem. Please try again", "ERROR");
                }


            }
        }
    }
}