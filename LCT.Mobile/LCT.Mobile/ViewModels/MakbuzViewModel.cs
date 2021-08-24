using LCT.Client.Utils;
using LCT.Dtos;
using LCT.Mobile.Client;
using LCT.Mobile.Client.Utils;
using LCT.Mobile.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace LCT.Mobile.ViewModels
{
    public class MakbuzViewModel: BaseViewModel
    {
        private List<MakbuzDto> _makbuzlar;
        public List<MakbuzDto> Makbuzlar
        {
            get => _makbuzlar;
            set => SetProperty(ref _makbuzlar, value);
        }

        public IMakbuzApi _makbuzApi;
        public MakbuzViewModel()
        {
            Title = "Makbuzlar";
            _makbuzApi = Refit.RestService.For<IMakbuzApi>(HttpClientFactory.Create(DefaultSettings.ApiUrl));
        }

        public override async Task InitializeAsync()
        {
            IsBusy = true;
            try
            {
                var makbuzlar = await _makbuzApi.Get();
               
                Makbuzlar = makbuzlar;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
