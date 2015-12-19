namespace CarSpending.Data.Localata.Models
{
    using System;
    using SQLite.Net.Attributes;

    public class Refueling
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public int CarId { get; set; }

        public decimal Price { get; set; }
        
        public double Quantity { get; set; }

        public int Odometer { get; set; }

        public int Distance { get; set; }

        public DateTime Date { get; set; }
    }
}
