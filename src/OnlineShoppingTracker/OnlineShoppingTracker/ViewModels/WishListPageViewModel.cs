using OnlineShoppingTracker.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OnlineShoppingTracker.ViewModels
{
	public class WishListPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private ObservableCollection<Product> wishListProducts;
        public ObservableCollection<Product> WishListProducts
        {
            get { return wishListProducts; }
            set { SetProperty(ref wishListProducts, value); }
        }

        public WishListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        // Add interface to ViewModelBase and override?
        public async void OnAppearing()
        {
            WishListProducts = new ObservableCollection<Product>(await App.Database.GetProductsWishListAsync());
        }

        public void OnDisappearing()
        {
        }
    }
}
