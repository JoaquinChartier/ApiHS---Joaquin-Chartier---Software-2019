using HearthDb.Deckstrings;
using HearthDb.Enums;
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

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    var deck = new Deck //Guarda en una variable, un nuevo objeto del tipo DECK
        //    {

        //        HeroDbfId = 7, //Id del Héroe
        //        CardDbfIds = new Dictionary<int, int>() //Diccionario que contiene las cartas del mazo
        //        {
        //            {1401, 2}, {440, 2}, {994, 2}, {38781, 2}, {1155, 2}, {40950, 2}, {46655, 2}, {374, 1},
        //            {41, 2}, {985, 2}, {289, 2}, {496, 2}, {2038, 2}, {997, 2}, {724, 2}, {2281, 1}
        //            // {dbfId/id de la carta, cantidad} //Las legendarias solo pueden tener una carta por mazo
        //     },
        //        Format = FormatType.FT_WILD, //Formato del mazo: FT_WILD o FT_STANDARD
        //        Name = "Mi Mazo personalizado", //Nombre del mazo, opcional
        //    };

        //    //Serializa el objeto DECK y lo guarda en la variable
        //    var deckstring = DeckSerializer.Serialize(deck,false); //El primer parámetro es el objeto, el segundo nos indica si contiene los comentarios del mazo o no
        //    Entrada.Text = deckstring;
        //}

        //private void Go_Clicked(object sender, EventArgs e)
        //{
        //    MazoModelo mazoModelo = new MazoModelo();
        //    mazoModelo.Clase = Clase.Text;
        //    mazoModelo.NombreMazo = NombreMazo.Text;
        //    //mazoModelo.ManaPromedio = ManaPromedio.Text;

        //    string textoAGuardar = JsonConvert.SerializeObject(mazoModelo);
        //    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedata222.txt"), textoAGuardar);
        //}

        //private void Mostrar_Clicked(object sender, EventArgs e)
        //{
        //    string textoLeido = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "savedata222.txt"));

        //    MazoModelo mazoDeserealizado = JsonConvert.DeserializeObject<MazoModelo>(textoLeido);
        //    Prueba.Text = mazoDeserealizado.NombreMazo;
        //}
    }
}