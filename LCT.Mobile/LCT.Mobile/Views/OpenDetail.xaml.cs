using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCT.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenDetail : ContentPage
    {
        public OpenDetail()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddReceipt());
           
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakbuzPage());
        }
    }
}