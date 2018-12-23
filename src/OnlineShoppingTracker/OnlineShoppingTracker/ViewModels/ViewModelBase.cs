using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingTracker.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool isBusy = true;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand);
        }

        private async void ExecuteNavigateCommand(string path)
        {
            var result = await NavigationService.NavigateAsync(path);
            if (!result.Success)
            {
                System.Diagnostics.Debug.WriteLine(result.Exception.Message);
            }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
