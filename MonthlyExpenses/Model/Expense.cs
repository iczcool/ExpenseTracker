using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MonthlyExpenses.Model
{
    public class Expense                                                                                                                                                                 
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Company { get; set; }
    }
}
