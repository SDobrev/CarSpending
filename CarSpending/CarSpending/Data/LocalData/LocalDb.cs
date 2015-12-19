namespace CarSpending.Data.LocalData
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.IO;
    using Windows.Storage;

    using CarSpending.Data.Localata.Models;

    public class LocalDb
    {
        public async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTablesAsync<Car, OtherExpense, Fueling>();
        }

        public SQLiteAsyncConnection GetDbConnectionAsync()
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
    }
}
