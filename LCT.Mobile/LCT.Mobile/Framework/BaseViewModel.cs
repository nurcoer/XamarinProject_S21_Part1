using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace LCT.Mobile.Framework
{
    public abstract class BaseViewModel: ObservableObject
    {
        private string _title;
        private bool _isBusy;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }
        public virtual Task OnDisappearingsync()
        {
            return Task.CompletedTask;
        }
        public virtual Task UninitializeAsync()
        {
            return Task.CompletedTask;
        }

    }
}
