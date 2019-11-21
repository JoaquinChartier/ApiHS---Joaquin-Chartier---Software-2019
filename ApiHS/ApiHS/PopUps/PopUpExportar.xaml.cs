using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HearthDb.Deckstrings;
using HearthDb.Enums;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpExportar
    {
        public MazoModelo MazoPorCrear = new MazoModelo();
        public string deckstring = "";

        public PopUpExportar()
        {
            InitializeComponent();
            ProcesoMayor();
        }

        private void CreacionMazo()
        {
            //Inicializa el diccionario
            MazoPorCrear.Cartas = new Dictionary<int, int>();
            //Lee el archivo de texto en el celular y lo deserealiza
            string mazoLeido = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "saveDataHS.txt"));
            MazoPorCrear = JsonConvert.DeserializeObject<MazoModelo>(mazoLeido);

            var deck = new Deck //Guarda en una variable, un nuevo objeto del tipo DECK
            {
                HeroDbfId = (int)HeroesEnum.Guldan, //Id del Héroe
                CardDbfIds = MazoPorCrear.Cartas, //Diccionario con las cartas
                Format = FormatType.FT_WILD, //Formato del mazo: FT_WILD o FT_STANDARD
                Name = "Mi Mazo personalizado", //Nombre del mazo, opcional
            };

            //Serializa el objeto DECK y lo guarda en la variable
            deckstring = DeckSerializer.Serialize(deck, false);
        }

        public async void ProcesoMayor() {
            //Proceso asincrono que permite que se cargue la pantalla PopUp mientras se crea el mazo
            await Task.Run(() => { CreacionMazo(); });
            //Asigna el codigo del mazo al entry
            Codigo.Text = deckstring;
            Copiar.IsVisible = true;
        }

        private async void CopiarCliqueado(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Mira mi nuevo mazo de HearthStone: \n" + deckstring,
                Title = "Mira mi nuevo mazo de HearthStone: "
            });
        }
    }
}