using CarSpending.Data.Localata.Models;
using CarSpending.Data.LocalData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CarSpending.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddFueling : Page
    {
        private LocalData localData;

        public AddFueling()
        {
            this.localData = new LocalData(new LocalDb());
            this.InitializeComponent();
        }

        private void AddNewFuelingButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            decimal price = 0;
            double quantity = 0;
            double distance = 0;

            int.TryParse(CarIdTextBox.Text, out id);
            decimal.TryParse(PriceTextBox.Text, out price);
            double.TryParse(QuantityTextBox.Text, out quantity);
            double.TryParse(DistanceTextBox.Text, out distance);

            var fueling = new Fueling
            {
                CarId = id,
                Price = price,
                Quantity = quantity,
                Distance = distance
            };

         //   this.localData.InsertFueling(fueling);
        }
    }
}
