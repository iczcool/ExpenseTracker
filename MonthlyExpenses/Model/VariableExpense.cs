using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonthlyExpenses.Model
{
    public class VariableExpense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
