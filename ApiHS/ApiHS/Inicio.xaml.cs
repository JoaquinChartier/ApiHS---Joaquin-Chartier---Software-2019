using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
        public ObservableCollection<string> Regiones;
        public string RegionSeleccionada;


        public Inicio ()
		{
			InitializeComponent ();
            //Inicializo el picker
            Regiones = new ObservableCollection<string>();
            Regiones.Add("Español - España");
            Regiones.Add("Español - Latinoamérica");
            Selector.ItemsSource = Regiones;
            //Chequeo si el usuario ya eligio su region previamente
            ChequeoRegion();
        }

        public async void ChequeoRegion() {
            if (Application.Current.Properties.ContainsKey("region"))
            {
                //Si contiene la key, pasa a la sig pagina, y elimina el boton "atras"
                await Navigation.PushAsync(new MainPage());
                NavigationPage.SetHasBackButton(this, false);
            }
            else
            {

                if (Selector.SelectedIndex == 0)
                {
                    RegionSeleccionada = "es_ES";
                }
                else
                {
                    RegionSeleccionada = "es_MX";
                }

                Application.Current.Properties["region"] = RegionSeleccionada;
            }
        }
	}
}