namespace CarSpending.Data.Localata.Models
{
    using System;
    using SQLite.Net.Attributes;

    public class OtherExpense
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public int CarId { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public ExpenseType Type { get; set; }
    }
}
