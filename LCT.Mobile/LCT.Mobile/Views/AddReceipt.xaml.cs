using LCT.Dtos;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LCT.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReceipt : ContentPage
    {

        public AddReceipt()
        {

            InitializeComponent();

        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            
          string action= await DisplayActionSheet("RECEIPT ADDED","CLOSE",null,"Receipts→");

            if (action == "Receipts→")
            {
              await  Navigation.PushAsync(new MakbuzPage());
            }

            else
            {
                await Navigation.PushAsync(new AddReceipt());
            }
           
        }


     


    }
}