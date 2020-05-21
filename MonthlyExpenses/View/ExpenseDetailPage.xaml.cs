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
    public partial class ExpenseDetailPage : ContentPage
    {
        int _id;
        private Expense myexp;
        private SQLiteConnection conn;
        public ExpenseDetailPage(int id)
        {
            _id = id;
            InitializeComponent();

            conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<Expense>();
            var expenses = conn.Table<Expense>().ToList();
            conn.Close();

            var exp = (from e in expenses
                       where e.Id == _id
                       select e).FirstOrDefault();

            myexp = new Expense();
            myexp.Name = exp.Name;
            myexp.Amount = exp.Amount;
            myexp.DueDate = exp.DueDate;
            myexp.Company = exp.Company;
            myexp.PaymentMethod = exp.PaymentMethod;

            name.Text = myexp.Name;
            amount.Text = myexp.Amount.ToString();
            duedate.Text = myexp.DueDate.ToString();
            company.Text = myexp.Company;
            paymethod.Text = myexp.PaymentMethod;
        }

        private void edit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditExpensePage(_id));
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<Expense>();
            conn.Table<Expense>().Delete(myexp => myexp.Id == _id);
            conn.Close();
            Navigation.PushAsync(new HomePage());
        }
    }
}