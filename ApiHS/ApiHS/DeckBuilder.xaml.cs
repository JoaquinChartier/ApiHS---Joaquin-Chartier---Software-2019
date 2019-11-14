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
            MazoPorAgregar.Cartas = new Dictionary<int, int>();
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

            //IF anidado que se ejecuta al seleccionar un index
            if (MazoPorAgregar.Cartas.ContainsKey(ResultList[IndexSeleccionado].id))//Chequea si la carta ya fue agregada
            {
                if ((MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id] == 2) ||//Chequea si no hay dos cartas iguales ya ingresadas
                    ((ResultList[IndexSeleccionado].rarityId == 5) && (MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id] == 1)))//O si la carta es una legendaria y solo hay una,(solo se permite una leg. por mazo)
                {
                    Agregar.SetValue(IsEnabledProperty, false);//si se cumplio alguna de las dos opciones desactiva el botón
                    //si es una rara setea el contador en 1/1, sino en 2/2
                    if (ResultList[IndexSeleccionado].rarityId == 5) { LabelContador.Text = "1/1"; }
                    else { LabelContador.Text = "2/2"; }
                }
                else { LabelContador.Text = "1/2"; }//Si la carta ya fue agregada, pero solo una vez setea en 1/2
            }
            else
            {//Si no fue agregada, el botón se mantiene encendido
                if (CantidadCartasMazo < 30) { Agregar.SetValue(IsEnabledProperty, true); } 
                //si es una rara setea el contador en 0/1, sino en 0/2
                if (ResultList[IndexSeleccionado].rarityId == 5) { LabelContador.Text = "0/1"; }
                else { LabelContador.Text = "0/2"; }
            }
        }

        private void AgregarCliqueado(object sender, EventArgs e)
        {//Este boton agrega la carta al mazo por construir
            if (MazoPorAgregar.Cartas.ContainsKey(ResultList[IndexSeleccionado].id) && (!(ResultList[IndexSeleccionado].rarityId == 5)))//Chequea si existe la key en el diccionario y no es una legendaria
            {
                MazoPorAgregar.Cartas[ResultList[IndexSeleccionado].id] = 2;//Si ya existe agrega una mas
                //si es una legendaria setea el contador en 1/1, sino en 2/2
                if (ResultList[IndexSeleccionado].rarityId == 5) { LabelContador.Text = "1/1"; }
                else { LabelContador.Text = "2/2"; }
            }
            else
            { //si es una legendaria...
                if (ResultList[IndexSeleccionado].rarityId == 5) {
                    if (MazoPorAgregar.Cartas.ContainsKey(ResultList[IndexSeleccionado].id))
                    { Agregar.SetValue(IsEnabledProperty, false); }//... y ya existe desactiva el boton
                    else { 
                    LabelContador.Text = "1/1";//si es legendaria pero no existe agrega una y desactiva el boton
                    MazoPorAgregar.Cartas.Add(ResultList[IndexSeleccionado].id, 1); 
                    Agregar.SetValue(IsEnabledProperty, false);
                    }
                }
                else
                {//si no es legendaria pero tampoco existe agrega una al diccionario
                    LabelContador.Text = "1/2";
                    MazoPorAgregar.Cartas.Add(ResultList[IndexSeleccionado].id, 1);
                }
                //Realizar aca prueba de escritorio
            }
            ChequeoCantidadCartasAgregadas();
        }

        private void ChequeoCantidadCartasAgregadas()
        {
            CantidadCartasMazo = MazoPorAgregar.Cartas.Values.Sum(); //Suma todos los values presentes en el diccionario
            TotalCartasMazo.Text = CantidadCartasMazo+"/30"; //Asigna el valor al label
            if (CantidadCartasMazo==30) { Agregar.SetValue(IsEnabledProperty, false); } //Si la cantidad llegó a 30, desactiva el botón
        }
    }
}
