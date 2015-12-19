namespace CarSpending.Data.LocalData
{
    using SQLite.Net.Async;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Repository<T> : IRepository<T> where T : class
    {
        private LocalDb db;
        private SQLiteAsyncConnection dbConnection;

        public Repository(LocalDb db)
        {
            this.db = db;
            this.dbConnection = this.db.GetDbConnectionAsync();
        }

        public async Task AddAsync(T item)
        {
            await this.dbConnection.InsertAsync(item);
        }

        public async Task DeleteAsync(T item)
        {
            await this.dbConnection.DeleteAsync(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> result;
            try
            {
                result = await this.dbConnection.Table<T>().ToListAsync();
            }
            catch (System.Exception)
            {
                result = new List<T>();
            }

            return result;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var result = await this.dbConnection.FindAsync<T>(id);
            if (result == null)
            {
                result = default(T);
            }

            return result;
        }

        public async Task UpdateAsync(T item)
        {
            await this.dbConnection.UpdateAsync(item);
        }
    }
}
