namespace CarSpending.Pages
{
    using CarSpending.DataModels;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using ViewModels;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AddVehicle : Page
    {
        public AddVehicle()
        {
            this.InitializeComponent();
            this.InitAsync();
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTablesAsync<Car, OtherExpense, Refueling>();
        }

        private async void AddCarButtonClick(object sender, RoutedEventArgs e)
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

            await this.InsertCarAsync(car);

            this.Frame.Navigate(typeof(MainPage));
        }

        private async Task<int> InsertCarAsync(Car car)
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.InsertAsync(car);
            return result;
        }
    }
}
