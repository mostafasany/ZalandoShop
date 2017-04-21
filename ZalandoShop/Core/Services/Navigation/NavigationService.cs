using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZalandoShop.Models.Enum;
using ZalandoShop.Services.Services.Navigation;
using ZalandoShop.UI.Views.Articles;

namespace ZalandoShop.Core.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        readonly Frame rootFrame;
        public Dictionary<string, Type> PagesByKey { get; set; }

        public NavigationService()
        {
            rootFrame = Window.Current.Content as Frame;
            PagesByKey = new Dictionary<string, Type>();
            SetupNavigation();
        }

        #region Private Methods

        private void Configure(string key, Type pageType)
        {
            if (PagesByKey.ContainsKey(key))
            {
                PagesByKey[key] = pageType;
            }
            else
            {
                PagesByKey.Add(key, pageType);
            }
        }

        #endregion

        public void Navigate(PageType type, object parameter = null)
        {
            string pageKey = type.ToString();
            if (!PagesByKey.ContainsKey(pageKey))
            {
                throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
            }

            Type pageType = PagesByKey[pageKey];
            rootFrame.Navigate(pageType, parameter);
        }

        public void NavigateBack()
        {
            rootFrame.GoBack();
        }

        public void SetupNavigation()
        {
            Configure(PageType.ArticlesSearchView.ToString(), typeof(ArticleSearchView));
            Configure(PageType.ArticlesSearchResult.ToString(), typeof(ArticleSearchResultsView));
        }
    }
}
