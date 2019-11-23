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
            { resultado = Color.Orange;
                return resultado;
            }
            else if (valor == 4)
            { resultado = Color.Violet;
                return resultado;
            }
            else if (valor == 3)
            { resultado = Color.Blue;
                return resultado;
            }
            else if (valor == 2)
            { resultado = Color.White;
                return resultado;
            }
            else /*(valor==1)*/
            { resultado = Color.Gray;
                return resultado;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
