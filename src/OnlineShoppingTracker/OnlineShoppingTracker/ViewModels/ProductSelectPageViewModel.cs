using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShoppingTracker.ViewModels
{
	public class ProductSelectPageViewModel : ViewModelBase
	{
        private string shopurl;
        public string ShopUrl
        {
            get { return shopurl; }
            set { SetProperty(ref shopurl, value); }
        }

        public ProductSelectPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            ShopUrl = parameters.GetValue<string>("shopUrl");
        }
    }
}
