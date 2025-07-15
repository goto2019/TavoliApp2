using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TavoliApp.Converters
{
    public class StringNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str &&
                decimal.TryParse(str, NumberStyles.Any, CultureInfo.GetCultureInfo("it-IT"), out var valore))
            {
                return valore > 0;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
