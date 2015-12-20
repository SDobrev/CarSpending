namespace CarSpending.Pages
{
    using CarSpending.Data.Localata.Models;
    using CarSpending.Data.LocalData;
    using Helpers;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class AddFueling : Page
    {
        private LocalData localData;
        private int carId;

        public AddFueling()
        {
            this.localData = new LocalData(new LocalDb());
            this.InitializeComponent();
        }
        
        private void AddNewFuelingButton_Click(object sender, RoutedEventArgs e)
        {
            decimal price = 0;
            double quantity = 0;
            double distance = 0;
            
            decimal.TryParse(PriceTextBox.Text, out price);
            double.TryParse(QuantityTextBox.Text, out quantity);
            double.TryParse(DistanceTextBox.Text, out distance);

            var fueling = new Fueling
            {
                CarId = carId,
                Price = price,
                Quantity = quantity,
                Distance = distance,
                Date = DateTime.UtcNow
            };

            if (quantity == 0 || distance == 0)
            {
                Notification.GetNotification("Error: Invalid Quantity or Distance!");
                return;
            }

            Notification.GetNotification("Success: Fueling added");
            this.localData.InsertFueling(fueling);
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.carId = int.Parse(e.Parameter.ToString());
        }
    }
}
