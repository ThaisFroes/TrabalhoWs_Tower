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
    public partial class FrmLogin : ContentPage
    {
        public FrmLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Btn_Login(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Master());
        }

        private void Btn_Cadastra(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FrmCadastro());
        }
    }
}