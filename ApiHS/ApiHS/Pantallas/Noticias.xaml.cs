using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiHS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Noticias : ContentPage
	{
        public string Region = Application.Current.Properties["region"] as string;

        public Noticias()
		{
			InitializeComponent ();
            WebView.Source = "https://playhearthstone.com/" + Region + "/"; //Asigno al webview la url
        }
	}
}