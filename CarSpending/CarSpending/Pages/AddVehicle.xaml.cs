namespace CarSpending.Pages
{
    using Data.Localata.Models;
    using Data.LocalData;
    using Helpers;
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
            //validate
            var year = 0;
            string make = this.MakeTextBox.Text;
            string model = this.ModelTextBox.Text;
            string image;

            //get from local
            if (this.ImgUrlTextBox.Text == string.Empty)
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
                Make = make,
                Model = model,
                ImgUrl = image,
                Year = year
            };
            
            if (false)
            {
                Notification.GetNotification("Error: .....");              
            }

            Notification.GetNotification("Success: Vehicle added");
            this.localData.InsertCar(car);
            this.Frame.Navigate(typeof(MainPage));
        }  
    }
}
