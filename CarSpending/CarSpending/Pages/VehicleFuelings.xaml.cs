using CarSpending.Data.Localata.Models;
using CarSpending.Data.LocalData;
using CarSpending.Helpers;
using CarSpending.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace CarSpending.Pages
{
    public sealed partial class VehicleFuelings : Page
    {
        private LocalData localData;
        private int vehicleId;

        public VehicleFuelings()
        {
            this.InitializeComponent();
            this.localData = new LocalData(new LocalDb());
            GetFuelings(vehicleId);
        }

        public async void GetFuelings(int id)
        {
            var contentViewModel = new FuelingsViewModel();
            var data = new List<FuelingsViewModel>();
            var vehicles = await localData.GetAllFuelingsAsync();

            foreach (var item in vehicles)
            {
                if(item.CarId == vehicleId)
                {
                    string date = item.Date.ToString("dd-MMM-yyyy");
                    data.Add(new FuelingsViewModel(item.Id, item.Quantity, item.Distance, item.Price, date));
                }
            }
            contentViewModel.Fuelings = data;

            this.DataContext = new FuelingsPageViewModel(contentViewModel);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            var fuelingId = (int)butt.CommandParameter;
            this.localData.DeleteFueling(fuelingId);
            Notification.GetNotification("Success: Fueling deleted!");
        }

        private void MyCarsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.vehicleId = int.Parse(e.Parameter.ToString());
        }
    }
}
