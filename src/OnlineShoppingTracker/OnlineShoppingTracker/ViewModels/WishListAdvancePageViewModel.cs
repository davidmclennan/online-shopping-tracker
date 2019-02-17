using OnlineShoppingTracker.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingTracker.ViewModels
{
	public class WishListAdvancePageViewModel : ViewModelBase
    {
        public IPageDialogService _dialogService;

        private Product product;
        public Product Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public DelegateCommand OrderedCommand { get; }

        public WishListAdvancePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            OrderedCommand = new DelegateCommand(ExecuteOrderedCommand);
        }

        private async void ExecuteOrderedCommand()
        {
            if (await _dialogService.DisplayAlertAsync("Advance Stage", "Are you sure you want to advance this product to orders?", "Yes", "Cancel"))
            {
                Product.Stage = "Orders";
                await App.Database.SaveProductAsync(Product);
                await NavigationService.GoBackAsync();
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Product = parameters.GetValue<Product>("product");
            Product.OrderDate = DateTime.Now;
        }
    }
}
