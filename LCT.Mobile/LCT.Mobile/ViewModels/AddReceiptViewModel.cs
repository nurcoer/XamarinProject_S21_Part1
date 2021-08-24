using LCT.Client.Utils;
using LCT.Dtos;
using LCT.Mobile.Client;
using LCT.Mobile.Client.Utils;
using LCT.Mobile.Framework;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;


namespace LCT.Mobile.ViewModels
{
    class AddReceiptViewModel : BaseViewModel
    {
        
        public ICommand AddCommand => new AsyncCommand(add);
        public ICommand TakePhoto => new AsyncCommand(TakePhotoAsync);
        private ImageSource image;
        public ImageSource CapImage
        {
            get => image;
            set
            {
                if (image == value)
                    return;
                image = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        private string _image;
        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        private DateTime? _date;
        public DateTime? Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        private int _amount;
        public int Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }


        public IMakbuzApi _makbuzApi;
        public AddReceiptViewModel()
        {
            _makbuzApi = Refit.RestService.For<IMakbuzApi>(HttpClientFactory.Create(DefaultSettings.ApiUrl));

        }
        private async Task add()
        {
            await _makbuzApi.Add(new MakbuzAddDto()
            {
                Name = Name,
                Description = Description,
                Date = Date,
                Amount = Amount,
                Image = Image,
            });
           
        } 
        
        private async Task TakePhotoAsync()
        {
            try
            {
                string action = await App.Current.MainPage.DisplayActionSheet("Choose An Option",
                    "Cancel",
                    null, "Choose From Library",
                    "Take Photo");

                if (action == "Cancel")
                {
                    return;
                }
                else if (action == "Choose From Library")
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    if (photo != null)
                        await LoadPhotoAsync(photo);

                }
                else if (action == "Take Photo")
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    var stream = await photo.OpenReadAsync();
                    CapImage = ImageSource.FromStream(() => stream);
                    if (photo != null)
                        await LoadPhotoAsync(photo);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (PermissionException pEx)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {

            if (photo == null)
            {
                Image = null;
                return;
            }
            using (var stream = await photo.OpenReadAsync())
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);

                    var resizedStream = new MemoryStream(ms.ToArray());

                    var image = await _makbuzApi.UploadImage(new Refit.StreamPart(resizedStream, photo.FileName, photo.ContentType));
                    Image = image; // {webadresi}/uploads/image.jpg
                }
            }
        }
    }
}