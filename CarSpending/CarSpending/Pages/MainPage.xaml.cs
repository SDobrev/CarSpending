namespace CarSpending.Pages
{
    using CarSpending.Data.LocalData;
    using CarSpending.ViewModels;
    using Helpers;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    public sealed partial class MainPage : Page
    {
        private LocalData localData;

        public MainPage()
        {
            this.InitializeComponent();
            this.localData = new LocalData(new LocalDb());
            GetVehicles();
        }

        public async void GetVehicles()
        {
            var contentViewModel = new VehiclesContentViewModel();
            var data = new List<VehiclesViewModel>();
            var vehicles = await localData.GetAllVehiclesAsync();

            foreach (var item in vehicles)
            {
                double consumption = (await localData.GetAvgConsumption(item.Id));
                string formatted = string.Format("{0:N2} l/100km", consumption);
                data.Add(new VehiclesViewModel(item.Id ,item.Make, item.Model, item.Year, item.ImgUrl, formatted));
            }
            contentViewModel.Vehicles = data;

            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        private void AddNewCarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddVehicle));
        }

        private void CurrentFuelPricesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrentPrices));
        }

        private void AddFuelingButton_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            var vehicleId = butt.CommandParameter;
            this.Frame.Navigate(typeof(AddFueling), vehicleId);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            var vehicleId = (int)butt.CommandParameter;
            this.localData.DeleteCar(vehicleId);
            Notification.GetNotification("Success: Vehicle deleted!");
        }

        private void ViewFuelingsButton_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            var vehicleId = (int)butt.CommandParameter;
            this.Frame.Navigate(typeof(VehicleFuelings), vehicleId);
        }
    }
}
