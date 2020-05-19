using MonthlyExpenses.Model;
using MonthlyExpenses.View;
using MonthlyExpenses.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonthlyExpenses.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        //Expense properties
        //private Expense expense = new Expense();
        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double amount;
        public double Amount
        {
            get { return amount; }
            set { 
                amount = value; 
                OnPropertyChanged("Amount"); 
            }
        }

        private DateTime duedate;
        public DateTime DueDate
        {
            get { return duedate; }
            set { duedate = value; OnPropertyChanged("DueDate"); }
        }

        private string paymentMethod;
        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; OnPropertyChanged("PaymentMethod"); }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; OnPropertyChanged("Company"); }
        }
    }
}
