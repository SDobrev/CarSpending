﻿namespace CarSpending.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IPageViewModel
    {
        public MainPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "My Vehicles";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}