using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ZalandoShop.UI.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var bol = (bool)value;
            if (!bol)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
