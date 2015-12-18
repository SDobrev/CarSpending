namespace CarSpending.ViewModels
{
    public class VehiclesViewModel : ViewModelBase
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public string Name { get; set; }

        public VehiclesViewModel()
            : this(string.Empty, string.Empty, 0, string.Empty)
        {
        }

        public VehiclesViewModel(VehiclesViewModel newVehicle)
            : this(newVehicle.Make, newVehicle.Model, newVehicle.Year, newVehicle.ImgUrl)
        {
        }

        public VehiclesViewModel(string make, string model, int Year, string imgUrl)
        {
            this.Make = make;
            this.Model = model;
            this.Year = Year;
            this.ImgUrl = imgUrl;
            this.Name = make + " " + model + " " + Year;
        }
    }
}