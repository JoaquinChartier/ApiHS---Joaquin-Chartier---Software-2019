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

namespace ApiHS
{
    public partial class DeckBuilder : ContentPage
    {
        public string Buscar ;
        public string Region = Application.Current.Properties["region"] as string;
        public string UrlJSON = "";
        private readonly HttpClient cliente = new HttpClient();
        public readonly string DevUser = "36e9d604cdd54ecd96a87ae552ba88b9";
        public readonly string DevSecret = "PcTsjma6pN94y1JgamKB0g4Ti2l6pZ6r";
        public string Token;
        public ObservableCollection<Card> ResultList { get; set; }
        public int IndexSeleccionado;

        public DeckBuilder()
        {
            InitializeComponent();
            TraerToken();
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
            BindingContext = this;

            Buscar = BarraBusqueda.Text;
            UrlJSON = "https://us.api.blizzard.com/hearthstone/cards?locale="+ Region +"&textFilter=" + Buscar + "&access_token=" + Token;
            string contenido = await cliente.GetStringAsync(UrlJSON); //le paso la url del JSON
            Root resultado = JsonConvert.DeserializeObject<Root>(contenido); //deserializo el JSON en un objeto del tipo "Root"
            ResultList = new ObservableCollection<Card>(resultado.cards); //guardo los resultados que necesito en una coleccion
            ListaResultados.ItemsSource = ResultList; //asigno los resultados al list view
        }

        private void ItemSeleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            IndexSeleccionado = e.SelectedItemIndex; //Guardo en variable el index del elemento seleccionado
            VisorCartas.Source = ResultList[IndexSeleccionado].image; //Asigno al visor la imagen correspondiente al index
        }
    }
}
