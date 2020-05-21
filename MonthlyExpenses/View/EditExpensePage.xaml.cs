using MonthlyExpenses.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonthlyExpenses.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditExpensePage : ContentPage
    {
        private int _id;
        private SQLiteConnection conn;
        public EditExpensePage(int id)
        {
            InitializeComponent();
            _id = id;

            conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<Expense>();
            var expenses = conn.Table<Expense>().ToList();
            conn.Close();

            var exp = (from e in expenses
                       where e.Id == _id
                       select e).FirstOrDefault();

            //name.Text = myexp.Name;
            //amount.Text = myexp.Amount.ToString();
            //duedate.Text = myexp.DueDate.ToString();
            //company.Text = myexp.Company;
            //paymethod.Text = myexp.PaymentMethod;

            ExpenseName.Text = exp.Name;
            Amount.Text = exp.Amount.ToString();
            DueDate.Date = exp.DueDate;
            PaymentMethod.Text = exp.PaymentMethod;
            Company.Text = exp.Company;
        }

        private void updatebtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ExpenseName.Text) || string.IsNullOrEmpty(Amount.Text))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Expense details", "OK");
            else
            {
                conn = new SQLiteConnection(App.DbLocation);
                conn.CreateTable<Expense>();

                Expense exp = new Expense();
                exp.Id = _id;
                exp.Name = ExpenseName.Text;
                exp.Amount = Double.Parse(Amount.Text);
                exp.DueDate = DueDate.Date;
                exp.PaymentMethod = PaymentMethod.Text;
                exp.Company = Company.Text;
                int rows = 0;
                try
                {
                    rows = conn.Update(exp);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (rows > 0)
                {
                    DisplayAlert("Success", "Expense Updated!", "Ok");
                    //App.Current.MainPage.DisplayAlert("Success", "New Expense added", "Ok");
                    App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    DisplayAlert("OOps!!!", "There was a problem. Please try again", "ERROR");
                }
            }
        }

        private void cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExpenseDetailPage(_id));
        }
    }
}