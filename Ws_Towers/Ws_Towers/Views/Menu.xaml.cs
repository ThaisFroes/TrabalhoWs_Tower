using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ws_Towers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Btn_Inicio(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Master());
        }

        private void Btn_Ingressos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FrmMeusIngressos());
        }

        private void Btn_Sobre(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FrmSobreApp());
        }

        private void Btn_Sair(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new FrmLogin());
        }
    }
}