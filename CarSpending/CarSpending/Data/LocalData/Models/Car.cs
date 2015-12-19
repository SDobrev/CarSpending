namespace CarSpending.Data.Localata.Models
{
    using SQLite.Net.Attributes;
    using SQLiteNetExtensions.Attributes;
    using System.Collections.Generic;

    public class Car
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string ImgUrl { get; set; }

        public int Year { get; set; }

        [OneToMany]
        public List<Fueling> Refuelings { get; set; }
    }
}
