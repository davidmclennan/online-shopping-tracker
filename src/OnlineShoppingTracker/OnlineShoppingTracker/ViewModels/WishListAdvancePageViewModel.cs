using OnlineShoppingTracker.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingTracker.ViewModels
{
	public class WishListAdvancePageViewModel : ViewModelBase
    {
        private Product product;
        public Product Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public DelegateCommand OrderedCommand { get; }

        public WishListAdvancePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            OrderedCommand = new DelegateCommand(ExecuteOrderedCommand);
        }

        private async void ExecuteOrderedCommand()
        {
            Product.Stage = "Orders";
            await App.Database.SaveProductAsync(Product);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Product = parameters.GetValue<Product>("product");
            Product.OrderDate = DateTime.Now;
        }
    }
}
