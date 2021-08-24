using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LCT.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenFlyout : ContentPage
    {
        public ListView ListView;

        public OpenFlyout()
        {
            InitializeComponent();

            BindingContext = new OpenFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class OpenFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<OpenFlyoutMenuItem> MenuItems { get; set; }

            public OpenFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<OpenFlyoutMenuItem>(new[]
                {
                    new OpenFlyoutMenuItem { Id = 0, Title = "Receipts" ,TargetType=typeof(MakbuzPage)},
                    new OpenFlyoutMenuItem { Id = 1, Title = "Add Receipt" ,TargetType =typeof(AddReceipt)},
                    new OpenFlyoutMenuItem { Id = 2, Title = "Edit Profile" },
                    new OpenFlyoutMenuItem { Id = 4, Title = "Log Out" },
                    
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}