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
            var year = 0;
            string make = this.MakeTextBox.Text;
            string model = this.ModelTextBox.Text;
            string image;
            
            if (this.ImgUrlTextBox.Text == string.Empty)
            {
                image = "ms-appx:///Assets/default-car.jpg";
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
            
            if (make.Length == 0 && model.Length == 0)
            {
                Notification.GetNotification("Error: Please fill make or model text");
                return;         
            }

            Notification.GetNotification("Success: Vehicle added");
            this.localData.InsertCar(car);
            this.Frame.Navigate(typeof(MainPage));
        }

        private void MyVehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
