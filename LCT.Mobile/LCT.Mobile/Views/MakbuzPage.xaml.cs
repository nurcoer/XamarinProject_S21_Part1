using LCT.Dtos;
using LCT.Mobile.Framework;
using LCT.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCT.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakbuzPage : BaseContentPage<MakbuzViewModel>
    {
        public MakbuzPage()
        {
            InitializeComponent();
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new MakbuzDetail(e.SelectedItem as MakbuzDto));
        }
    }
}