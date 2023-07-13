using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xapp.Services;
using xapp.Views;

namespace xapp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Home());


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
