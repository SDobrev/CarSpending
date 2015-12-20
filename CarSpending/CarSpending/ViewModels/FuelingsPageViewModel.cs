using CarSpending.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSpending.ViewModels
{
    public class FuelingsPageViewModel : ViewModelBase, IPageViewModel
    {
        public FuelingsPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "My Vehicle Fuelings";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
