using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinConexion : ContentPage
    {
        public SinConexion()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {//Al presionar el Botón fisico del celular, cierra la App
            Application.Current.Quit();
            return false; // if you return true here, the app won't close
        }
    }
}