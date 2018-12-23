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
        bool firstLoad = true;

        private string shopurl;
        public string ShopUrl
        {
            get { return shopurl; }
            set { SetProperty(ref shopurl, value); }
        }

        public DelegateCommand FirstLoadCommand { get; }

        public ProductSelectPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            FirstLoadCommand = new DelegateCommand(ExecuteFirstLoadCommand);
        }

        private void ExecuteFirstLoadCommand()
        {
            if (firstLoad)
            {
                IsBusy = false;
                firstLoad = false;
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            ShopUrl = parameters.GetValue<string>("shopUrl");
        }
    }
}
