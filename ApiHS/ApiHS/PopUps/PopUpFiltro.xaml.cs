using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpFiltro 
    {
        public PopUpFiltro()
        {
            InitializeComponent();
            //Extrae de la clase literals los textos de los pickers, y los asigna.
            SelectorMecanica.ItemsSource = Modelos.Literals.SelectorMecanica(Application.Current.Properties["region"] as string);
            SelectorRareza.ItemsSource = Modelos.Literals.SelectorVariado("rareza");
            SelectorTipo.ItemsSource = Modelos.Literals.SelectorVariado("tipo");
            SelectorTipoEsbirro.ItemsSource = Modelos.Literals.SelectorVariado("tipoesbirro");
            
        }

        private async void ConfirmarCliqueado(object sender, EventArgs e)
        {
            int indexTipo = SelectorTipo.SelectedIndex;
            int indexRareza = SelectorRareza.SelectedIndex;
            int indexMecanica = SelectorMecanica.SelectedIndex;
            int indexTipoEsbirro = SelectorTipoEsbirro.SelectedIndex;
            //Asigna las variables de la pantalla deckbuilder, segun el index seleccionado en el picker
            DeckBuilder.TipoCarta = Modelos.Literals.TipoINSelector()[indexTipo].ToString();
            DeckBuilder.Rareza = Modelos.Literals.RarezaINSelector()[indexRareza].ToString();
            DeckBuilder.Mecanica = Modelos.Literals.MecanicaINSelector()[indexMecanica].ToString();
            DeckBuilder.TipoEsbirro = Modelos.Literals.TipoEsbirroINSelector()[indexTipoEsbirro].ToString();
            //Cierra el PopUp
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}