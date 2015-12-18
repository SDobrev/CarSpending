using CarSpending.DataModels;
using CarSpending.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSpending.ViewModels
{
    public class VehiclesContentViewModel : ViewModelBase, IContentViewModel
    {

        public ObservableCollection<VehiclesViewModel> vehicles;

        public IEnumerable<VehiclesViewModel> Vehicles
        {
            get
            {
                if (this.vehicles == null)
                {
                    this.vehicles = new ObservableCollection<VehiclesViewModel>();
                }

                return this.vehicles;
            }
            set
            {
                if (this.vehicles == null)
                {
                    this.vehicles = new ObservableCollection<VehiclesViewModel>();
                }

                this.vehicles.Clear();
                value.ForEach(this.vehicles.Add);
            }
        }
    }
}
