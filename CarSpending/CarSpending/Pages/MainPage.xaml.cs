using CarSpending.Data.LocalData;
using CarSpending.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CarSpending.Pages
{

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
                data.Add(new VehiclesViewModel(item.Id ,item.Make, item.Model, item.Year, item.ImgUrl));
            }
            contentViewModel.Vehicles = data;

            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        // not working ..
        private void ListBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddFueling));
        }

        private void AddNewCarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddVehicle));
        }

        private void CurrentFuelPricesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrentPrices));
        }
    }
}
