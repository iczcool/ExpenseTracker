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
    public partial class VEDetailPage : ContentPage
    {
        int _id;
        private VariableExpense myexp;
        private SQLiteConnection conn;
        public VEDetailPage(int id)
        {
            _id = id;
            InitializeComponent();

            conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<VariableExpense>();
            var expenses = conn.Table<VariableExpense>().ToList();
            conn.Close();

            var exp = (from e in expenses
                       where e.Id == _id
                       select e).FirstOrDefault();

            myexp = new VariableExpense();
            myexp.Name = exp.Name;
            myexp.Amount = exp.Amount;
            myexp.DueDate = exp.DueDate;
            myexp.Description = exp.Description;

            name.Text = myexp.Name;
            amount.Text = myexp.Amount.ToString();
            duedate.Text = myexp.DueDate.ToString();
            description.Text = myexp.Description;
        }

        private void edit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditVEPage(_id));
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(App.DbLocation);
            conn.CreateTable<VariableExpense>();
            conn.Table<VariableExpense>().Delete(myexp => myexp.Id == _id);
            conn.Close();
            Navigation.PushAsync(new VariableExpensesPage());
        }
    }
}