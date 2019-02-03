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
	public class PurchaseListPageViewModel : ProductListViewModelBase
	{
        public DelegateCommand<Product> ReturningCommand { get; }

        public PurchaseListPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            ReturningCommand = new DelegateCommand<Product>(ExecuteReturningCommand);
        }

        private async void ExecuteReturningCommand(Product product)
        {
            if (await _dialogService.DisplayAlertAsync("Returning Product", "Are you sure you want to advance this product to returns?", "Yes", "Cancel"))
            {
                product.Stage = "Returns";
                await App.Database.SaveProductAsync(product);
                await LoadProducts();
            }
        }

        public override async Task LoadProducts()
        {
            IsBusy = true;
            Products = new ObservableCollection<Product>(await App.Database.GetProductsPurchasesAsync());
            IsBusy = false;
        }
    }
}
