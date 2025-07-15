using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TavoliApp.Converters
{
    public class TotaleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Models.TavoloDto tavolo &&
                decimal.TryParse(tavolo.TotaleStringaRaw, out var totale))
            {
                return totale > 0 ? Colors.Red : Colors.Green;
            }
            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

