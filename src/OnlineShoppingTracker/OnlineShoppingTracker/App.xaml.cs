using Prism;
using Prism.Ioc;
using OnlineShoppingTracker.ViewModels;
using OnlineShoppingTracker.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OnlineShoppingTracker
{
    public partial class App
    {
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

            await NavigationService.NavigateAsync("MainPage/StagesTabbedPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<StagesTabbedPage, StagesTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<WishListPage, WishListPageViewModel>();
            containerRegistry.RegisterForNavigation<PurchaseListPage, PurchaseListPageViewModel>();
            containerRegistry.RegisterForNavigation<ReturnListPage, ReturnListPageViewModel>();
            containerRegistry.RegisterForNavigation<KeptListPage, KeptListPageViewModel>();
            containerRegistry.RegisterForNavigation<ShopListPage, ShopListPageViewModel>();
        }
    }
}
