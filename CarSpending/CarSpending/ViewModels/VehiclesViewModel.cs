namespace CarSpending.ViewModels
{
    public class VehiclesViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public string Name { get; set; }

        public double Consumption { get; set; }

        public VehiclesViewModel()
            : this(0, string.Empty, string.Empty, 0, string.Empty)
        {
        }

        public VehiclesViewModel(VehiclesViewModel newVehicle)
            : this(newVehicle.Id, newVehicle.Make, newVehicle.Model, newVehicle.Year, newVehicle.ImgUrl)
        {
        }

        public VehiclesViewModel(int id, string make, string model, int Year, string imgUrl)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = Year;
            this.ImgUrl = imgUrl;
            this.Name = make + " " + model + " " + Year;
        }
    }
}