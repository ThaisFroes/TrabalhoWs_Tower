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
    public partial class FrmSplash : ContentPage
    {
        public FrmSplash()
        {
            InitializeComponent();
            Animation();
        }

        public async Task Animation()
        {
            logoImagem.Opacity = 0;
            await logoImagem.FadeTo(1, 5000);
            App.Current.MainPage = new NavigationPage(new FrmLogin());
        }
    }
}