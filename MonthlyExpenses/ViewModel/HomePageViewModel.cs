using MonthlyExpenses.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonthlyExpenses.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        private Expense expense = new Expense();

        public string Name
        {
            get { return expense.Name; }
            set
            {
                expense.Name = "Fuck Off";
                OnPropertyChanged("Fuck Off");
            }
        }

        public string Amount
        {
            get { return expense.Amount; }
            set { 
                expense.Amount = value; 
                OnPropertyChanged("1400.0"); 
            }
        }
    }
}
