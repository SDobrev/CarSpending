namespace CarSpending.Pages
{
    using Data.Localata.Models;
    using Data.LocalData;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AddVehicle : Page
    {
        private LocalData localData;

        public AddVehicle()
        {
            this.InitializeComponent();
            this.localData = new LocalData(new LocalDb());
        }

        private void AddCarButtonClick(object sender, RoutedEventArgs e)
        {
            var year = 0;
            string image;
            if(this.ImgUrlTextBox.Text == string.Empty)
            {
               image = "http://www.eztriplimo.com/wp-content/plugins/limollabs-service/themes/default/img/default-car.jpg";
            }
            else
            {
                image = this.ImgUrlTextBox.Text;
            }            

            int.TryParse(this.YearTextBox.Text, out year);
            var car = new Car
            {
                Make = this.MakeTextBox.Text,
                Model = this.ModelTextBox.Text,
                ImgUrl = image,
                Year = year
            };

            this.localData.InsertCar(car);

            this.Frame.Navigate(typeof(MainPage));
        }

  
    }
}
