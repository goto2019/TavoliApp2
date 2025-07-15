using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TavoliApp.Converters
{
    public class StatoToStyleConverter : IValueConverter
    {
        public Style TavoloLiberoStyle { get; set; }
        public Style TavoloOccupatoStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.ToString().ToLower() == "libero")
                return Application.Current.Resources["TavoloLiberoStyle"];
            else
                return Application.Current.Resources["TavoloOccupatoStyle"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
