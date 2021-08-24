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
using Xamarin.Forms;

namespace LCT.Mobile.ViewModels
{

    public class MakbuzDetailViewModel : BaseViewModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private MakbuzDetailDto _makbuz;
        public MakbuzDetailDto Makbuz
        {
            get => _makbuz;
            set => SetProperty(ref _makbuz, value);
        }

        public IMakbuzApi _makbuzApi;
        public MakbuzDetailViewModel()
        {
            _makbuzApi = Refit.RestService.For<IMakbuzApi>(HttpClientFactory.Create(DefaultSettings.ApiUrl));
        }

        public override async Task InitializeAsync()
        {

            IsBusy = true;

            try
            {
                Makbuz = new MakbuzDetailDto();
                var makbuz = await _makbuzApi.GetById(Id);
                Makbuz = makbuz;
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

