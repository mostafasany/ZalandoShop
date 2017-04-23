using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ZalandoShop.Core.Services.Internet;
using ZalandoShop.Services.Services.Article;
using ZalandoShop.Services.Services.Facet;
using ZalandoShop.Services.Services.Internet;
using ZalandoShop.Services.Services.Network;

namespace ZalandoShop.Core
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            RegisterServices();
        }

        void RegisterServices()
        {
            SimpleIoc.Default.Register<IInternetService, InternetService>();
            SimpleIoc.Default.Register<INetworkService, NetworkService>();
            SimpleIoc.Default.Register<IArticleService, ArticleService>();
            SimpleIoc.Default.Register<IFacetService, FacetService>();
        }

    }
}