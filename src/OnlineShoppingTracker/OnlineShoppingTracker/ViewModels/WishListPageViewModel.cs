using OnlineShoppingTracker.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingTracker.ViewModels
{
	public class WishListPageViewModel : ProductListViewModelBase
    {
        public DelegateCommand<Product> PurchasedCommand { get; }

        public WishListPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            PurchasedCommand = new DelegateCommand<Product>(ExecutePurchasedCommand);
        }

        private async void ExecutePurchasedCommand(Product product)
        {
            if (await _dialogService.DisplayAlertAsync("Purchased Product", "Are you sure you want to advance this product to purchases?", "Yes", "Cancel"))
            {
                product.Stage = "Purchases";
                await App.Database.SaveProductAsync(product);
                await LoadProducts();
            }
        }

        public override async Task LoadProducts()
        {
            IsBusy = true;
            Products = new ObservableCollection<Product>(await App.Database.GetProductsWishListAsync());
            IsBusy = false;
        }
    }
}
