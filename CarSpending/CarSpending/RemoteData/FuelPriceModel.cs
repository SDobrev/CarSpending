namespace CarSpending.RemoteData
{
    using Newtonsoft.Json;

    [JsonObject]
    public class FuelPriceModel
    {
        public FuelPriceModel()
            : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public FuelPriceModel(string type, string price, string dimension, string date)
        {
            this.Type = type;
            this.Price = price;
            this.Dimension = dimension;
            this.Date = date;
        }

        [JsonProperty("fuel")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
