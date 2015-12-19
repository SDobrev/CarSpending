namespace CarSpending.Data.LocalData
{
    using Localata.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class LocalData
    {
        private LocalDb context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public LocalData(LocalDb context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of LocalDb is required to use this repository.", nameof(context));
            }

            this.context = context;
            this.context.InitAsync();
        }

        public IRepository<Car> Cars => this.GetLocalRepository<Car>();

        public async Task<IEnumerable<Car>> GetAllVehiclesAsync()
        {
            var allCars = await this.Cars.GetAllAsync();

            return allCars;
        }

        public void InsertCar(Car car)
        {
            var result = this.Cars.AddAsync(car);
            //var connection = this.GetDbConnectionAsync();
            //var result = await connection.InsertAsync(car);
        }

        private IRepository<T> GetLocalRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                this.repositories.Add(typeOfModel, new Repository<T>(this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
