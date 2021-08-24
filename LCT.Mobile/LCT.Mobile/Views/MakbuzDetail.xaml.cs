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
    public partial class MakbuzDetail : BaseContentPage<MakbuzDetailViewModel>
    {
        public MakbuzDetail(MakbuzDto makbuz)
        {
            InitializeComponent();
            var viewModel = BindingContext as MakbuzDetailViewModel;
            viewModel.Id = makbuz.Id;

        }


    }
}
