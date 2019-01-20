using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShoppingTracker.Models;

namespace OnlineShoppingTracker.ViewModels
{
	public class ProductPopupPageViewModel : BindableBase
	{
        private Product product;
        public Product Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public DelegateCommand<string> PriorityCommand { get; }
        public DelegateCommand<string> StageCommand { get; }

        public ProductPopupPageViewModel()
        {
            Product = new Product { Priority = "Low", Stage = "Wish List" };

            PriorityCommand = new DelegateCommand<string>(ExecutePriorityCommand);
            StageCommand = new DelegateCommand<string>(ExecuteStageCommand);
        }

        private void ExecutePriorityCommand(string priority)
        {
            Product.Priority = priority;
            RaisePropertyChanged(nameof(Product));
        }

        private void ExecuteStageCommand(string stage)
        {
            Product.Stage = stage;
            RaisePropertyChanged(nameof(Product));
        }
    }
}
