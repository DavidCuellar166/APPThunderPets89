using PIAAppProgra.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PIAAppProgra
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new IndexMenu());
            MainPage = new NavigationPage(new LoginPage());
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
