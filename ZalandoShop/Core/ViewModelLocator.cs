using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ZalandoShop.Core.Services.Navigation;
using ZalandoShop.Services.Services.Navigation;
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