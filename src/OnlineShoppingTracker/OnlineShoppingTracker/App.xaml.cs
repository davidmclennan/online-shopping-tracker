using Prism;
using Prism.Ioc;
using OnlineShoppingTracker.ViewModels;
using OnlineShoppingTracker.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Plugin.Popups;
using OnlineShoppingTracker.Data;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OnlineShoppingTracker
{
    public partial class App
    {
        static ProductDatabase database;

        public static ProductDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OnlineShoppingTracker.db3"));
                }
                return database;
            }
        }

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Start(this);
#endif

            await NavigationService.NavigateAsync("MainPage/StagesTabbedPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // This updates INavigationService and registers PopupNavigation.Instance
            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<StagesTabbedPage, StagesTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<WishListPage, WishListPageViewModel>();
            containerRegistry.RegisterForNavigation<PurchaseListPage, PurchaseListPageViewModel>();
            containerRegistry.RegisterForNavigation<ReturnListPage, ReturnListPageViewModel>();
            containerRegistry.RegisterForNavigation<KeptListPage, KeptListPageViewModel>();
            containerRegistry.RegisterForNavigation<ShopListPage, ShopListPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductSelectPage, ProductSelectPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductPopupPage, ProductPopupPageViewModel>();
            containerRegistry.RegisterForNavigation<OrderListPage, OrderListPageViewModel>();
            containerRegistry.RegisterForNavigation<WishListAdvancePage, WishListAdvancePageViewModel>();
        }
    }
}
