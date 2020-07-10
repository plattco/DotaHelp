using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotaHelp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DB.OpenConnection();
            MainPage = new NavigationPage(new DotaHelp.MainPage());
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
