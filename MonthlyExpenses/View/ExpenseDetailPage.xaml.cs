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
        public ExpenseDetailPage()
        {
            InitializeComponent();

            SQLiteConnection conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<Expense>();
            var expenses = conn.Table<Expense>().ToList();
            conn.Close();

            var exp = (from e in expenses
                       where e.Id == 2
                       select e).FirstOrDefault();

            Expense myexp = new Expense();
            myexp.Name = exp.Name;
            myexp.Amount = exp.Amount;
            myexp.DueDate = exp.DueDate;
            myexp.Company = exp.Company;
            myexp.PaymentMethod = exp.PaymentMethod;

            name.Text = myexp.Name;
            amount.Text = myexp.Amount;
            duedate.Text = myexp.DueDate;
            company.Text = myexp.Company;
            paymethod.Text = myexp.PaymentMethod;
        }

        private void edit_Clicked(object sender, EventArgs e)
        {
           
        }

        private void delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}