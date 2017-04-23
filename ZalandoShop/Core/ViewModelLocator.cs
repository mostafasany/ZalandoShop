using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ZalandoShop.Core.Services.Dialog;
using ZalandoShop.Core.Services.Internet;
using ZalandoShop.Core.Services.Navigation;
using ZalandoShop.Services.Services.Article;
using ZalandoShop.Services.Services.Dialog;
using ZalandoShop.Services.Services.Facet;
using ZalandoShop.Services.Services.Internet;
using ZalandoShop.Services.Services.Navigation;
using ZalandoShop.Services.Services.Network;
using ZalandoShop.ViewModels.ViewModel;

namespace ZalandoShop.Core
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegisterViewModels();
            RegisterServices();
        }

        void RegisterViewModels()
        {
            SimpleIoc.Default.Register<ArticleSearchViewModel>();
            SimpleIoc.Default.Register<ArticleSearchResultsViewModel>();
        }

        void RegisterServices()
        {
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IInternetService, InternetService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<INetworkService, NetworkService>();
            SimpleIoc.Default.Register<IArticleService, ArticleService>();
            SimpleIoc.Default.Register<IFacetService, FacetService>();
        }
        public ArticleSearchViewModel ArticleSearchViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ArticleSearchViewModel>();
            }
        }

        public ArticleSearchResultsViewModel ArticleSearchResultsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ArticleSearchResultsViewModel>();
            }
        }
    }
}