namespace CarSpending.DataModels
{
    using SQLite.Net.Attributes;
    using System.Collections.Generic;
    using ViewModels;

    public class Car
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string ImgUrl { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"#{this.Id}; Make: {this.Make}; Model: {this.Model}; ImgUrl: {this.ImgUrl}; Year: {this.Year}";
        }
    }
}
