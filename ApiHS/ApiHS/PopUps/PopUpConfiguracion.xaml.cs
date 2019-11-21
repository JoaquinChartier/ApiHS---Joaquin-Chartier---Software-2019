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
	public partial class PopUpConfiguracion 
	{
		public PopUpConfiguracion ()
		{
			InitializeComponent();
            SelectorClase.Items.Add("Garrosh");
            SelectorClase.Items.Add("Rexxar");
            SelectorClase.Items.Add("Jaina");
            SelectorClase.Items.Add("Uther");
            SelectorClase.Items.Add("Malfurion");
            SelectorClase.Items.Add("Gul´Dan");
            SelectorClase.Items.Add("Thrall");
            SelectorClase.Items.Add("Valeera");
            SelectorClase.Items.Add("Anduin");

        }

        private void SwitchFormatoCambiado(object sender, ToggledEventArgs e)
        {
            if (SwitchFormato.IsToggled)
            {
                lblEstandar.FontAttributes = FontAttributes.Bold;
                lblSalvaje.FontAttributes = FontAttributes.None;
            }
            else {
                lblEstandar.FontAttributes = FontAttributes.None;
                lblSalvaje.FontAttributes = FontAttributes.Bold;
            }
        }
    }
}