using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ApiHS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Si el usuario tiene conexión, lo redirije a la APP
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (Application.Current.Properties.ContainsKey("region"))//Chequeo si el usuario ya eligio su region previamente
                {
                    //Si contiene la key, pasa a la sig pagina.
                    MainPage = new NavigationPage(new MainPage());
                    //MainPage = new Wiki();
                }
                else
                {
                    //Si no redirije a la pantalla de seleccion de region.
                    MainPage = new NavigationPage(new Inicio());
                }
            }
            else
            {
                MainPage = new SinConexion();
            }
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
