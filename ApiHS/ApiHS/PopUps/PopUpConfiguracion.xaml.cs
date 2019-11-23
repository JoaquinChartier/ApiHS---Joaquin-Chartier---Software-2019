﻿using Newtonsoft.Json;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpConfiguracion 
	{
        public MazoModelo MazoActual = new MazoModelo();

        public PopUpConfiguracion ()
		{
			InitializeComponent();
            AlAparecer();
        }

        private void AlAparecer()
        {//Este metodo se ejecuta al aparecer la pantalla
            //Inicializacion del picker
            SelectorClase.Items.Add("Garrosh");
            SelectorClase.Items.Add("Rexxar");
            SelectorClase.Items.Add("Jaina");
            SelectorClase.Items.Add("Uther");
            SelectorClase.Items.Add("Malfurion");
            SelectorClase.Items.Add("Guldan");
            SelectorClase.Items.Add("Thrall");
            SelectorClase.Items.Add("Valeera");
            SelectorClase.Items.Add("Anduin");
            //Carga de los datos
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt")))
            {
                string mazoPorLeer = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt"));
                MazoActual = JsonConvert.DeserializeObject<MazoModelo>(mazoPorLeer);

                EntryNombre.Text = MazoActual.NombreMazo;
                SelectorClase.SelectedItem = MazoActual.Clase.ToString();
                if (MazoActual.TipoMazo==HearthDb.Enums.FormatType.FT_STANDARD)
                { SwitchFormato.IsToggled=true; }
                else { SwitchFormato.IsToggled = false; }
            }

        }

        private void SwitchFormatoCambiado(object sender, ToggledEventArgs e)
        {
            if (SwitchFormato.IsToggled)
            {
                lblEstandar.FontAttributes = FontAttributes.Bold;
                lblSalvaje.FontAttributes = FontAttributes.None;
                Application.Current.Properties["formato"] = "standard";
            }
            else {
                lblEstandar.FontAttributes = FontAttributes.None;
                lblSalvaje.FontAttributes = FontAttributes.Bold;
                Application.Current.Properties["formato"] = "wild";
            }
        }

        private async void ConfirmarCliqueado(object sender, EventArgs e)
        {//Se ejecuta al cliquear el boton
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt")))
            {//Si el archivo existe, lo lee y le sobreescribe la nueva informacion
                string mazoPorLeer = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt"));
                MazoActual = JsonConvert.DeserializeObject<MazoModelo>(mazoPorLeer);


                MazoActual.NombreMazo = EntryNombre.Text;
                string claseElegida = SelectorClase.SelectedItem.ToString();
                MazoActual.Clase = (HeroesEnum)Enum.Parse(typeof(HeroesEnum), claseElegida);

                if (SwitchFormato.IsToggled)
                { MazoActual.TipoMazo = HearthDb.Enums.FormatType.FT_STANDARD; }
                else { MazoActual.TipoMazo = HearthDb.Enums.FormatType.FT_WILD; }

                string mazoAGuardar = JsonConvert.SerializeObject(MazoActual);
                File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt"), mazoAGuardar);

            }
            else
            { //Si no existe lo crea
                MazoActual.NombreMazo = EntryNombre.Text;
                string claseElegida = SelectorClase.SelectedItem.ToString();
                MazoActual.Clase = (HeroesEnum)Enum.Parse(typeof(HeroesEnum), claseElegida);

                if (SwitchFormato.IsToggled)
                { MazoActual.TipoMazo = HearthDb.Enums.FormatType.FT_STANDARD; }
                else { MazoActual.TipoMazo = HearthDb.Enums.FormatType.FT_WILD; }

                string mazoAGuardar = JsonConvert.SerializeObject(MazoActual);
                File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt"), mazoAGuardar);
            }
            
            //Cierra el PopUp
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}