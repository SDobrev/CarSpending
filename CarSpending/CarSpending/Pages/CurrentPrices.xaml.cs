using CarSpending.Data.RemoteData;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CarSpending.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrentPrices : Page
    {
        private const string Url = "http://fuelo.net/api/price?key=beb5cdf4554ce11&fuel=";

        private readonly HttpClient httpClient;

        public CurrentPrices()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
        }

        private async void GetButtonClick(object sender, RoutedEventArgs e)
        {
            this.Gasoline.Text = string.Empty;
            var gasolineString = await this.ReadAsString(Url + "gasoline");
            this.Gasoline.Text = gasolineString;

            var dieselString = await this.ReadAsString(Url + "diesel");
            this.Diesel.Text = dieselString;

            var lpgString = await this.ReadAsString(Url + "lpg");
            this.LPG.Text = lpgString;

            var methaneString = await this.ReadAsString(Url + "methane");
            this.Methane.Text = methaneString;
        }

        private async Task<string> ReadAsString(string url)
        {
            var response = await this.httpClient.GetAsync(new Uri(url));
            var result = await response.Content.ReadAsStringAsync();
            var rootObject = JsonConvert.DeserializeObject<FuelPriceModel>(result);
            return rootObject.Price + " " + rootObject.Dimension;
        }

        private void MyVehiclesButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
