using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HearthDb.Deckstrings;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckBuilder : ContentPage
    {
        public string Buscar;
        public string Region = Application.Current.Properties["region"] as string;
        public string UrlJSON = "";
        private readonly HttpClient cliente = new HttpClient();
        public readonly string DevUser = "36e9d604cdd54ecd96a87ae552ba88b9";
        public readonly string DevSecret = "PcTsjma6pN94y1JgamKB0g4Ti2l6pZ6r";
        public string Token;
        public ObservableCollection<Card> ResultList { get; set; }
        public int IndexSeleccionado;
        public MazoModelo MazoPorAgregar = new MazoModelo();
        public int CantidadCartasMazo;



        public DeckBuilder()
        {
            InitializeComponent();
            TraerToken();
            MazoPorAgregar.Cartas = new Dictionary<int, int>(); //Inicializo el diccionario
        }

        private void TraerToken()
        {
            var client = new RestClient("https://us.battle.net"); //le paso la url para hacer el request
            client.Authenticator = new HttpBasicAuthenticator(DevUser, DevSecret);//le paso los datos de auth(user y pass)
            var request = new RestRequest("/oauth/token", Method.POST); //le digo el resource y el metodo
            request.AddParameter("grant_type", "client_credentials"); // ingreso los parametros para hacer request
            var response = client.Execute<SolicitudHTTP>(request); // ejecuta el request y lo deserializa automaticamente
            Token = response.Data.access_token; //asigno el token a la variable token
        }

        public async void AlCliquear(object sender, EventArgs e)
        {
            Buscar = BarraBusqueda.Text;
            UrlJSON = "https://us.api.blizzard.com/hearthstone/cards?locale=" + Region + "&textFilter=" + Buscar + "&access_token=" + Token;
            string contenido = await cliente.GetStringAsync(UrlJSON); //le paso la url del JSON
            Root resultado = JsonConvert.DeserializeObject<Root>(contenido); //deserializo el JSON en un objeto del tipo "Root"
            ResultList = new ObservableCollection<Card>(resultado.cards); //guardo los resultados que necesito en una coleccion
            ListaResultados.ItemsSource = ResultList; //asigno los resultados al list view
        }

        private void ItemSeleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            IndexSeleccionado = e.SelectedItemIndex; //Guardo en variable el index del elemento seleccionado
            VisorCartas.Source = ResultList[IndexSeleccionado].image; //Asigno al visor la imagen correspondiente al index

            var esLegendaria = ResultList[IndexSeleccionado].rarityId == 5;
            var fueAgregada = MazoPorAgregar.Cartas.ContainsKey(ResultList[IndexSeleccionado].id);

            if (fueAgregada)//Chequea si la carta ya fue agregada
            {
                Borrar.IsVisible = true;
                SetterLabelContador();
            }
            else
            {   
                Borrar.IsVisible = false;
                if (CantidadCartasMazo < 30) {Agregar.SetValue(IsEnabledProperty, true);}//Si no fue agregada, el botón se enciende
                SetterLabelContador();
            }
        }

        private void AgregarCliqueado(object sender, EventArgs e)
        {
            var esLegendaria = ResultList[IndexSeleccionado].rarityId == 5;
            var fueAgregada = MazoPorAgregar.Cartas.ContainsKey(ResultList[IndexSeleccionado].id);
                              
            if (fueAgregada && (!esLegendaria))//Chequea si existe la key en el diccionario y no es una legendaria
            {
                MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id] = 2;//Si ya existe agrega una mas
                SetterLabelContador();
                Agregar.SetValue(IsEnabledProperty, false);
            }
            else
            { //si es una legendaria...
                if (esLegendaria) {
                    if (fueAgregada)
                    { Agregar.SetValue(IsEnabledProperty, false); } //... y ya existe desactiva el boton
                    else { 
                    //si es legendaria pero no existe agrega una y desactiva el boton
                    MazoPorAgregar.Cartas.Add(ResultList[IndexSeleccionado].id, 1);
                    SetterLabelContador();
                    Agregar.SetValue(IsEnabledProperty, false);
                    Borrar.IsVisible = true;
                    }
                }
                else
                {//si no es legendaria pero tampoco existe agrega una al diccionario
                    MazoPorAgregar.Cartas.Add(ResultList[IndexSeleccionado].id, 1);
                    SetterLabelContador();
                    Borrar.IsVisible = true;
                }
            }
            SetterCantidadCartasAgregadas();
        }

        private void SetterCantidadCartasAgregadas()
        {
            CantidadCartasMazo = MazoPorAgregar.Cartas.Values.Sum(); //Suma todos los values presentes en el diccionario
            TotalCartasMazo.Text = CantidadCartasMazo+"/30"; //Asigna el valor al label
            if (CantidadCartasMazo==30) { Agregar.SetValue(IsEnabledProperty, false); } //Si la cantidad llegó a 30, desactiva el botón
        }

        private void BorrarCliqueado(object sender, EventArgs e)
        {
            var esLegendaria = ResultList[IndexSeleccionado].rarityId == 5;
            if (esLegendaria)
            {
                MazoPorAgregar.Cartas.Remove(ResultList[IndexSeleccionado].id);
                Borrar.IsVisible = false;
                SetterCantidadCartasAgregadas();
                SetterLabelContador();
                Agregar.SetValue(IsEnabledProperty, true);
            }
            else
            {
                if (MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id] == 2)
                {
                    MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id] = 1;
                    SetterCantidadCartasAgregadas();
                    SetterLabelContador();
                }
                else
                {
                    MazoPorAgregar.Cartas.Remove(ResultList[IndexSeleccionado].id);
                    Borrar.IsVisible = false;
                    SetterCantidadCartasAgregadas();
                    SetterLabelContador();
                }
                Agregar.SetValue(IsEnabledProperty, true);
            }
        }

        private void SetterLabelContador()
        {
            var esLegendaria = ResultList[IndexSeleccionado].rarityId == 5;
            var fueAgregada = MazoPorAgregar.Cartas.ContainsKey(ResultList[IndexSeleccionado].id);

            if (fueAgregada)
            {
                var valueActual = MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id].ToString();
                if (esLegendaria) { LabelContador.Text = "1/1"; }
                else {
                    LabelContador.Text = valueActual + "/2";
                    if (valueActual == "1") { Agregar.SetValue(IsEnabledProperty, true); }
                     }
            }
            else
            {
                if (esLegendaria) { LabelContador.Text = "0/1"; }
                else { LabelContador.Text = "0/2"; }
            }
        }
    }
}
