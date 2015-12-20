namespace CarSpending.Data.LocalData
{
    using Localata.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public IRepository<Fueling> Fuelings => this.GetLocalRepository<Fueling>();


        public async Task<IEnumerable<Car>> GetAllVehiclesAsync()
        {
            var allCars = await this.Cars.GetAllAsync();

            return allCars;
        }

        public async Task<IEnumerable<Fueling>> GetAllFuelingsAsync()
        {
            var allFuelings = (await this.Fuelings.GetAllAsync());

            return allFuelings;
        }

        public async Task<double> GetAvgConsumption(int carId)
        {
            double consumption = 0;
            var carFuelings = new List<double>();
            var allFuelings = (await this.Fuelings.GetAllAsync());
            foreach (var item in allFuelings)
            {
                if(item.CarId == carId)
                {
                    carFuelings.Add(item.Consumption);
                }
            }
            for (int i = 0; i < carFuelings.Count; i++)
            {
                consumption += carFuelings[i];
            }
            if(carFuelings.Count == 0)
            {
                return 0.00;
            }

            return consumption / carFuelings.Count;
        }

        public void InsertCar(Car car)
        {
            var result = this.Cars.AddAsync(car);
        }

        public async void DeleteCar(int id)
        {
            var carToDelele = await this.Cars.GetByIdAsync(id);
            var result = this.Cars.DeleteAsync(carToDelele);
        }

        public void InsertFueling(Fueling fueling)
        {
            var result = this.Fuelings.AddAsync(fueling);
        }

        public async void DeleteFueling(int id)
        {
            var fuelingToDelete = await this.Fuelings.GetByIdAsync(id);
            var result = this.Fuelings.DeleteAsync(fuelingToDelete);
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
