using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShoppingTracker.ViewModels
{
	public class WishListPageViewModel : ViewModelBase
	{
        public WishListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
	}
}
