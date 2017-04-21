using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ZalandoShop.Services.Services.Navigation;

namespace ZalandoShop.ViewModels.ViewModel
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
            // SimpleIoc.Default.Register<INavigationService, NavigationService>();
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