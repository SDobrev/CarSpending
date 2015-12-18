namespace CarSpending.Pages
{
    using CarSpending.DataModels;
    using CarSpending.ViewModels;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitAsync();
            GetVehicles();
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

        private async void GetVehicles()
        {
            var contentViewModel = new VehiclesContentViewModel();
            var data = new List<VehiclesViewModel>();
            var vehicles = await GetAllVehiclesAsync();
            foreach (var item in vehicles)
            {
                data.Add(new VehiclesViewModel(item.Make, item.Model, item.Year, item.ImgUrl));
            }
            contentViewModel.Vehicles = data;

            this.DataContext = new MainPageViewModel(contentViewModel);
        }


        public async Task<List<Car>> GetAllVehiclesAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.Table<Car>().ToListAsync();
            return result;
        }

        private void AddNewCarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddVehicle));
        }
    }
}
