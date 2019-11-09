using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Wiki : ContentPage
	{
		public Wiki ()
		{
			InitializeComponent();
		}

        //private void Go_Clicked(object sender, EventArgs e)
        //{
        //    MazoModelo mazoModelo = new MazoModelo();
        //    mazoModelo.Clase = Clase.Text;
        //    mazoModelo.NombreMazo = NombreMazo.Text;
        //    //mazoModelo.ManaPromedio = ManaPromedio.Text;

        //    string textoAGuardar = JsonConvert.SerializeObject(mazoModelo);
        //    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedata.txt"), textoAGuardar);
        //}

        //private void Mostrar_Clicked(object sender, EventArgs e)
        //{
        //    string textoLeido = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedata.txt"));

        //    MazoModelo mazoDeserealizado = JsonConvert.DeserializeObject<MazoModelo>(textoLeido);
        //    Prueba.Text = mazoDeserealizado.NombreMazo;
        //}
    }
}