using System;
using System.Globalization;
using Xamarin.Forms;

namespace ApiHS.Converters
{
    public class EntryNombreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value > 0) //Si se ingreso texto en el entry, es true
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
