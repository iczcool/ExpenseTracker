using MonthlyExpenses.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MonthlyExpenses.ViewModel.Commands
{
    public class TestCommand : ICommand
    {
        public ExpenseDetailPage expenseDetail;

        public event EventHandler CanExecuteChanged;
        public TestCommand()
        {
            expenseDetail = new ExpenseDetailPage();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //expenseDetail.Show();
        }
    }
}
