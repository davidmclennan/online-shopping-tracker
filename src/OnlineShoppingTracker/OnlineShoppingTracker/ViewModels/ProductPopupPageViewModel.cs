using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShoppingTracker.Models;
using Prism.Navigation;

namespace OnlineShoppingTracker.ViewModels
{
	public class ProductPopupPageViewModel : ViewModelBase
	{
        private Product product;
        public Product Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public DelegateCommand<string> PriorityCommand { get; }
        public DelegateCommand<string> StageCommand { get; }
        public DelegateCommand SaveProductCommand { get; }

        public ProductPopupPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Product = new Product { Priority = "LOW", Stage = "Wish List" };

            PriorityCommand = new DelegateCommand<string>(ExecutePriorityCommand);
            StageCommand = new DelegateCommand<string>(ExecuteStageCommand);
            SaveProductCommand = new DelegateCommand(ExecuteSaveProductCommand);
        }

        private void ExecutePriorityCommand(string priority)
        {
            Product.Priority = priority;
            RaisePropertyChanged(nameof(Product));
        }

        private void ExecuteStageCommand(string stage)
        {
            Product.Stage = stage;
            RaisePropertyChanged(nameof(Product));
        }

        private async void ExecuteSaveProductCommand()
        {
            await App.Database.SaveProductAsync(Product);
            await NavigationService.GoBackAsync();
        }
    }
}
