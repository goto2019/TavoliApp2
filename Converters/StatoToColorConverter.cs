using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using TavoliApp.Models;

namespace TavoliApp.Converters
{
    public class TotaleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TavoloDto tavolo)
            {
                return tavolo.Totale > 0 ? Colors.IndianRed : Colors.LightGreen;
            }

            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}

