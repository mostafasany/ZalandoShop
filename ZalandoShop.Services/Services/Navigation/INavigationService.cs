using System;
using System.Collections.Generic;
using ZalandoShop.Models.Enum;

namespace ZalandoShop.Services.Services.Navigation
{
    public interface INavigationService
    {
        Dictionary<string, Type> PagesByKey { get; set; }
        void Navigate(PageType type, object parameter = null);
        void NavigateBack();
        void SetupNavigation();
    }
}
