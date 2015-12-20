using CarSpending.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarSpending.ViewModels
{
    public class FuelingsViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<FuelingsViewModel> fuelings;

        public int Id { get; set; }

        public double Quantity { get; set; }

        public double Distance { get; set; }

        public decimal Price { get; set; }

        public double Consumption { get; set; }

        public string Date { get; set; }

        public FuelingsViewModel()
            : this(0, 0, 0, 0, string.Empty, 0)
        {
        }

        public FuelingsViewModel(FuelingsViewModel newFueling)
            : this(newFueling.Id, newFueling.Quantity, newFueling.Distance, newFueling.Price, newFueling.Date, newFueling.Consumption)
        {
        }

        public FuelingsViewModel(int id, double quantity, double distance, decimal price, string date,double consumption)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Distance = distance;
            this.Price = price;
            this.Date = date;
            this.Consumption = consumption;
        }

        public IEnumerable<FuelingsViewModel> Fuelings
        {
            get
            {
                if (this.fuelings == null)
                {
                    this.fuelings = new ObservableCollection<FuelingsViewModel>();
                }

                return this.fuelings;
            }
            set
            {
                if (this.fuelings == null)
                {
                    this.fuelings = new ObservableCollection<FuelingsViewModel>();
                }

                this.fuelings.Clear();
                value.ForEach(this.fuelings.Add);
            }
        }
    }
}
