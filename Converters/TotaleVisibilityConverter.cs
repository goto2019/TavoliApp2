using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TavoliApp.Converters
{
    public class TotaleVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string totale && totale.Trim() != "0,00")
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
