using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TavoliApp.Converters
{
    public class StringToBoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Se la stringa è non vuota e diversa da "0,00", restituisce Bold, altrimenti Normal
            if (value is string str && !string.IsNullOrWhiteSpace(str) && str != "0,00")
                return FontAttributes.Bold;

            return FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack non è supportato.");
        }
    }
}
