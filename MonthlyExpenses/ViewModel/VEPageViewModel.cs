using System;
using System.Collections.Generic;
using System.Text;

namespace MonthlyExpenses.ViewModel
{
    public class VEPageViewModel : BaseViewModel
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
            set
            {
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

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
    }
}
