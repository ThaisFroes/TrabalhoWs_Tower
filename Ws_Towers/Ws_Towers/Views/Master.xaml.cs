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
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Master = new Menu();
            this.Detail = new NavigationPage(new FrmPrincipal());
        }
    }
}