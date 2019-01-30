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
        public WishListPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {

        }

        public override async Task LoadProducts()
        {
            IsBusy = true;
            Products = new ObservableCollection<Product>(await App.Database.GetProductsWishListAsync());
            IsBusy = false;
        }
    }
}
