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
    public partial class EditVEPage : ContentPage
    {
        private int _id;
        private SQLiteConnection conn;
        public EditVEPage(int id)
        {
            InitializeComponent();
            _id = id;

            conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<VariableExpense>();
            var variableExpenses = conn.Table<VariableExpense>().ToList();
            conn.Close();

            var vexp = (from e in variableExpenses
                       where e.Id == _id
                       select e).Single();

            //name.Text = myexp.Name;
            //amount.Text = myexp.Amount.ToString();
            //duedate.Text = myexp.DueDate.ToString();
            //company.Text = myexp.Company;
            //paymethod.Text = myexp.PaymentMethod;

            ExpenseName.Text = vexp.Name;
            Amount.Text = vexp.Amount.ToString();
            DueDate.Date = vexp.DueDate;
            Description.Text = vexp.Description;
        }


        private void updatebtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ExpenseName.Text) || string.IsNullOrEmpty(Amount.Text))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Expense details", "OK");
            else
            {
                conn = new SQLiteConnection(App.DbLocation);
                conn.CreateTable<VariableExpense>();

                VariableExpense vexp = new VariableExpense();
                vexp.Id = _id;
                vexp.Name = ExpenseName.Text;
                vexp.Amount = Double.Parse(Amount.Text);
                vexp.DueDate = DueDate.Date;
                vexp.Description = Description.Text;
                int rows = 0;
                try
                {
                    rows = conn.Update(vexp);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (rows > 0)
                {
                    DisplayAlert("Success", "Variable Expense Updated!", "Ok");
                    //App.Current.MainPage.DisplayAlert("Success", "New Expense added", "Ok");
                    App.Current.MainPage.Navigation.PushAsync(new VariableExpensesPage());
                }
                else
                {
                    DisplayAlert("OOps!!!", "There was a problem. Please try again", "ERROR");
                }
            }
        }
        private void cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VariableExpensesPage());
        }
    }
}