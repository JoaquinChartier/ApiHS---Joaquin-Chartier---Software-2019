using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ApiHS.Converters
{
    public class RarezaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (int)value;
            Color resultado;

            if (valor == 5)
            {
                resultado = Color.FromHex("#e68a00");
                return resultado;
            }
            else if (valor == 4)
            { resultado = Color.FromHex("#602772");
                return resultado;
            }
            else if (valor == 3)
            {
                resultado = Color.FromHex("#004de6");
                return resultado;
            }
            else if (valor == 2)
            {
                resultado = Color.FromHex("#a6a6a6");
                return resultado;
            }
            else /*(valor==1)*/
            {
                resultado = Color.FromHex("#cccccc"); 
                return resultado;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
