﻿using OnlineShoppingTracker.Models;
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
    public abstract class ProductListViewModelBase : ViewModelBase, IPageLifecycleAware
    {
        public IPageDialogService _dialogService;

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        public DelegateCommand<Product> DeleteCommand { get; }

        public ProductListViewModelBase(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            DeleteCommand = new DelegateCommand<Product>(ExecuteDeleteCommand);
        }

        private async void ExecuteDeleteCommand(Product product)
        {
            if (await _dialogService.DisplayAlertAsync("Delete Product", "Are you sure you want to delete this product?", "Yes", "Cancel"))
            {
                await App.Database.DeleteProductAsync(product);
                await LoadProducts();
            }
        }

        public abstract Task LoadProducts();

        public async void OnAppearing()
        {
            await LoadProducts();
        }

        public void OnDisappearing()
        {
        }
    }
}
