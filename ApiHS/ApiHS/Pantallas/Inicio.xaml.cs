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
			InitializeComponent();
            InicializacionPicker();
        }

        public void InicializacionPicker() {
            //Inicializo el picker
            Regiones = new ObservableCollection<string>();
            Regiones.Add("Español - España");
            Regiones.Add("Español - Latinoamérica");
            Selector.ItemsSource = Regiones;
        }

        public void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Selector.SelectedIndex == 0)
            {//Si la opcion elegida es la primera setea la region como España
                RegionSeleccionada = "es_ES";
            }
            else
            {//Si la opcion elegida es la segunda setea la region como Latinoamerica
                RegionSeleccionada = "es_MX";
            }

            Application.Current.Properties["region"] = RegionSeleccionada;
            Application.Current.Properties["formato"] = "standard";
            Navigation.PushModalAsync(new MainPage());
        }
    }
}