﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LCT.Mobile.Framework
{
    public abstract class BaseContentPage<T> : ContentPage
       where T : BaseViewModel
    {
        private bool isAlreadyInitialized;
        private bool isAlreadyUninitialized;

        protected virtual T ViewModel => BindingContext as T;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!isAlreadyInitialized)
            {
                ViewModel.InitializeAsync();
                isAlreadyInitialized = true;
            }
            ViewModel.OnAppearingAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (!isAlreadyUninitialized)
            {
                ViewModel.UninitializeAsync();
                isAlreadyUninitialized = true;
            }
            ViewModel.OnDisappearingsync();
        }
    }
}
