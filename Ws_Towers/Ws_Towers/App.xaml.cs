using System;
using Ws_Towers.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ws_Towers
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new FrmSplash();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
