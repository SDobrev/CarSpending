namespace CarSpending.Data.Localata.Models
{
    using System;
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;
    public class Fueling
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Car))]
        public int CarId { get; set; }

        public decimal Price { get; set; }
        
        public double Quantity { get; set; }

        public double Odometer { get; set; }

        public double Distance { get; set; }

        public double Consumption { get; set; }

        public DateTime Date { get; set; }

        [ManyToOne]
        public Car Car { get; set; }
    }
}
