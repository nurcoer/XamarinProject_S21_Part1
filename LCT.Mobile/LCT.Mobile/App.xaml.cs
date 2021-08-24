using LCT.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Montserrat-Regular.ttf", Alias = "FontFam")]
[assembly: ExportFont("Montserrat-Bold.ttf",Alias="FontFamB")]
namespace LCT.Mobile
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();

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
